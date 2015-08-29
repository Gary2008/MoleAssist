// inlineHook.cpp : 定义 InlineHook 类。
//

#include "stdafx.h"
#include "InlineHook.h"

// 有关类定义的信息，请参阅 inlineHook.h
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
	//检查参数
	if (funcAddr == nullptr || jmpFuncAddr == nullptr)
	{
		return false;
	}
	//检查class内部状态
	if (_status != STATUS::NOTHING)
	{
		return false;
	}
	//准备工作
	(UINT&) _jmpBytes[1] = (UINT)jmpFuncAddr - (UINT)funcAddr - 5;
	DWORD dwFlag;
	//修改保护标志
	if (VirtualProtect(funcAddr, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//保存入口
		memcpy(_oldBytes, funcAddr, JMP_LEN);
		//写入JMP
		memcpy(funcAddr, _jmpBytes, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//改变标识
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
	//修改保护标志
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//还原入口
		memcpy(_addrFunc, _oldBytes, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//重置
		memset(_oldBytes, 0, JMP_LEN);
		memset(_jmpBytes, 0, JMP_LEN);
		_addrFunc = nullptr;
		_addrJmp = nullptr;
		if (_hModule != nullptr) {
			FreeLibrary(_hModule);
			_hModule = nullptr;
		}
		//改变标识
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
	//修改保护标志
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//还原入口
		memcpy(_addrFunc, _oldBytes, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//改变标识
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
	//修改保护标志
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//写入JMP
		memcpy(_addrFunc, _jmpBytes, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//改变标识
		_status = STATUS::WORKING;
		return true;
	}
	return false;
}
