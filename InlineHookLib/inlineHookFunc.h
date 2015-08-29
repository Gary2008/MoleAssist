#pragma once
// 将类 inlineHook 包装为导出函数

#include "inlineHook.h"

extern "C" {
	INLINEHOOKLIB_API InlineHook* CreateHook();
	INLINEHOOKLIB_API void DestoryHook(InlineHook* pHook);
	INLINEHOOKLIB_API bool InstallHook(InlineHook* pHook, LPCWSTR dll, LPCSTR apiName, PVOID jmpFuncAddr);
	INLINEHOOKLIB_API bool UninstallHook(InlineHook* pHook);
	INLINEHOOKLIB_API bool SuspendHook(InlineHook* pHook);
	INLINEHOOKLIB_API bool ResumeHook(InlineHook* pHook);
}