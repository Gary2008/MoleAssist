// inlineHook.cpp : ���� InlineHook �ࡣ
//

#include "stdafx.h"
#include "InlineHook.h"

// �й��ඨ�����Ϣ������� inlineHook.h
inline InlineHook::InlineHook()
	: _status(STATUS::NOTHING),
	_addrFunc(nullptr), _addrJmp(nullptr),
	_oldBytes{0, 0, 0, 0, 0}, _jmpBytes{0xE9, 0, 0, 0, 0},
	_hModule(nullptr)
{
    return;
}

inline InlineHook::~InlineHook()
{
	if (_status != STATUS::NOTHING)
	{
		this->uninstall();
	}
	return;
}

bool InlineHook::install(LPCWSTR dll, LPCSTR apiName, PVOID jmpFuncAddr)
{
	HMODULE hMoudle = LoadLibrary(dll);
	if (hMoudle != nullptr)
	{
		PVOID funcAddr = (PVOID)GetProcAddress(hMoudle, apiName);
		if (funcAddr == nullptr)
		{
			FreeLibrary(hMoudle);
			return false;
		}
		_hModule = hMoudle;
		return install(funcAddr, jmpFuncAddr);
	}
	return false;
}

bool InlineHook::install(PVOID funcAddr, PVOID jmpFuncAddr)
{
	//������
	if (funcAddr == nullptr || jmpFuncAddr == nullptr)
	{
		return false;
	}
	//���class�ڲ�״̬
	if (_status != STATUS::NOTHING)
	{
		return false;
	}
	//׼������
	(UINT&) _jmpBytes[1] = (UINT)jmpFuncAddr - (UINT)funcAddr - 5;
	DWORD dwFlag;
	//�޸ı�����־
	if (VirtualProtect(funcAddr, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//�������
		memcpy(_oldBytes, funcAddr, JMP_LEN);
		//д��JMP
		memcpy(funcAddr, _jmpBytes, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//�ı��ʶ
		_addrFunc = funcAddr;
		_addrJmp = jmpFuncAddr;
		_status = STATUS::WORKING;
		return true;
	}
	return false;
}

bool InlineHook::uninstall()
{
	if (_status == STATUS::NOTHING)
	{
		return false;
	}
	assert(_addrFunc != nullptr);
	DWORD dwFlag;
	//�޸ı�����־
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//��ԭ���
		memcpy(_addrFunc, _oldBytes, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//����
		memset(_oldBytes, 0, JMP_LEN);
		memset(_jmpBytes, 0, JMP_LEN);
		_addrFunc = nullptr;
		_addrJmp = nullptr;
		if (_hModule != nullptr) {
			FreeLibrary(_hModule);
			_hModule = nullptr;
		}
		//�ı��ʶ
		_status = STATUS::NOTHING;
		return true;
	}
	return false;
}

bool InlineHook::suspend()
{
	if (_status != STATUS::WORKING)
	{
		return false;
	}
	assert(_addrFunc != nullptr);
	DWORD dwFlag;
	//�޸ı�����־
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//��ԭ���
		memcpy(_addrFunc, _oldBytes, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//�ı��ʶ
		_status = STATUS::SUSPEEDED;
		return true;
	}
	return false;
}

bool InlineHook::resume()
{
	if (_status != STATUS::SUSPEEDED)
	{
		return false;
	}
	assert(_addrFunc != nullptr);
	DWORD dwFlag;
	//�޸ı�����־
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//д��JMP
		memcpy(_addrFunc, _jmpBytes, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//�ı��ʶ
		_status = STATUS::WORKING;
		return true;
	}
	return false;
}
