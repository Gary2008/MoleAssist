// InlineHookLib.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "InlineHookLib.h"
#include <vector>

// 有关类定义的信息，请参阅 InlineHookLib.h
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
	//检查参数
	if (pFunc == nullptr || pJmpfunc == nullptr)
	{
		return false;
	}
	//检查class内部状态
	if (_status != STATUS::NOTHING)
	{
		return false;
	}
	//准备工作
	_addrFunc = pFunc;
	(UINT&) _jmpBytes[1] = (UINT)pJmpfunc - (UINT)_addrFunc - 5;
	DWORD dwFlag;
	//修改保护标志
	if (VirtualProtect(_addrFunc, JMP_LEN, PAGE_EXECUTE_READWRITE, &dwFlag))
	{
		//保存入口
		memcpy(_oldBytes, _addrFunc, JMP_LEN);
		//写入JMP
		RtlCopyMemory(_addrFunc, _jmpBytes, JMP_LEN);
		memcpy(_addrFunc, _jmpBytes, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//改变标识
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
		memcpy(_oldBytes, _addrFunc, JMP_LEN);
		//还原保护标志
		VirtualProtect(_addrFunc, JMP_LEN, dwFlag, &dwFlag);
		//重置
		memset(_oldBytes, 0, JMP_LEN);
		memset(_jmpBytes, 0, JMP_LEN);
		_addrFunc = nullptr;
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
