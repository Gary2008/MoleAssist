#pragma once
// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� INLINEHOOKLIB_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// INLINEHOOKLIB_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef INLINEHOOKLIB_EXPORTS
#define INLINEHOOKLIB_API __declspec(dllexport)
#else
#define INLINEHOOKLIB_API __declspec(dllimport)
#endif

#define WIN32_LEAN_AND_MEAN
#include <windows.h>

class INLINEHOOKLIB_API InlineHook {
public:
	InlineHook();
	~InlineHook();
	bool install(PVOID funcAddr, PVOID jmpFuncAddr);
	bool install(LPCWSTR dll, LPCSTR apiName, PVOID jmpFuncAddr);
	bool uninstall();
	bool suspend();
	bool resume();
private:
	static const int JMP_LEN = 5;
	enum STATUS { NOTHING, WORKING, SUSPEEDED };
	HMODULE _hModule;
	PVOID _addrFunc;
	PVOID _addrJmp;
	BYTE _oldBytes[JMP_LEN];
	BYTE _jmpBytes[JMP_LEN];
	STATUS _status;
};