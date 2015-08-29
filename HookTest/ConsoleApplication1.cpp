// ConsoleApplication1.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
#include "..\InlineHookLib\inlineHookFunc.h"

int WINAPI test(HWND h, LPCSTR c, LPCSTR t, UINT utype) {

	printf("HOOK success! \n");
	printf("HWND%d \n %s %s %d\n", h, c, t, utype);
	return 0;
}

int main()
{
	//InlineHook hook;
	//hook.install(MessageBoxA, test);
	//MessageBoxA(nullptr, "testContent", "testTitle", 0);
	//hook.suspend();
	//MessageBoxA(nullptr, "testContent", "testTitle", 0);
	//hook.resume();
	//MessageBoxA(nullptr, "testContent", "testTitle", 0);
	//hook.uninstall();
	//MessageBoxA(nullptr, "testContent", "testTitle", 0);

	MessageBoxA(nullptr, "testContent", "testTitle", 0);
	InlineHook* a = CreateHook();
	std::cout << "install \n==============\n";
	InstallHook(a, L"user32.dll", "MessageBoxA", test);
	MessageBoxA(nullptr, "testContent", "testTitle", 0);
	std::cout << "suspend \n==============\n";
	SuspendHook(a);
	MessageBoxA(nullptr, "testContent", "testTitle", 0);
	std::cout << "resume \n==============\n";
	ResumeHook(a);
	MessageBoxA(nullptr, "testContent", "testTitle", 0);
	std::cout << "destory \n==============\n";
	DestoryHook(a);
	MessageBoxA(nullptr, "testContent", "testTitle", 0);

	system("pause");
    return 0;
}