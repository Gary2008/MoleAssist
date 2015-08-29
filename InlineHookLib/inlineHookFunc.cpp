// 将类 inlineHook 包装为函数

#include "stdafx.h"
#include "inlineHookFunc.h"

InlineHook* CreateHook()
{
	return new InlineHook();
};
void DestoryHook(InlineHook* pHook)
{
	delete pHook;
};

bool InstallHook(InlineHook* pHook, LPCWSTR dll, LPCSTR apiName, PVOID jmpFuncAddr)
{
	return pHook->install(dll, apiName, jmpFuncAddr);
};
bool UninstallHook(InlineHook* pHook)
{
	return pHook->uninstall();
};
bool SuspendHook(InlineHook* pHook)
{
	return pHook->suspend();
};
bool ResumeHook(InlineHook* pHook)
{
	return pHook->resume();
};
