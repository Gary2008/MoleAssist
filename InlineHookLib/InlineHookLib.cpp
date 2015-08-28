// InlineHookLib.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"
#include "InlineHookLib.h"
#include <vector>

// �й��ඨ�����Ϣ������� InlineHookLib.h
inline InlineHook::InlineHook()
	: _status(STATUS::NOTHING), _oldBytes{}, _jmpBytes{0xE9, 0, 0, 0, 0}
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

bool InlineHook::install(PVOID pFunc, PVOID pJmpfunc)
{
	//������
	if (pFunc == nullptr || pJmpfunc == nullptr)
	{
		return false;
	}
	//���class�ڲ�״̬
	if (_status != STATUS::NOTHING)
	{
		return false;
	}
	//׼������
	_addrFunc = pFunc;
	(UINT&) _jmpBytes[1] = (UINT)pJmpfunc - (UINT)_addrFunc - 5;
	DWORD dwFlag;
	//�޸ı�����־
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//�������
		memcpy(_oldBytes, _addrFunc, JMP_LEN);
		//д��JMP
		RtlCopyMemory(_addrFunc, _jmpBytes, JMP_LEN);
		memcpy(_addrFunc, _jmpBytes, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//�ı��ʶ
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
		memcpy(_oldBytes, _addrFunc, JMP_LEN);
		//��ԭ������־
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//����
		memset(_oldBytes, 0, JMP_LEN);
		memset(_jmpBytes, 0, JMP_LEN);
		_addrFunc = nullptr;
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
