#include "StdAfx.h"
#include "ioextension.h"
#include "extmdl.h"

IOExtension::IOExtension(void)
{
    hmodule = LoadLibrary("ExtMdl.dll");
    if (!hmodule) {
        throw ("ExtMdl.dll load fail");
    }
}


IOExtension::~IOExtension(void)
{
    Close();
    FreeLibrary(hmodule);
    hmodule = NULL;
}

short IOExtension::Open()
{
    GT_OpenExtMdl f = (GT_OpenExtMdl)GetProcAddress(hmodule, "GT_OpenExtMdl");
    short sRtn = f("gts.dll");

    if (!sRtn) {
        GT_LoadExtConfig f = (GT_LoadExtConfig)GetProcAddress(hmodule, "GT_LoadExtConfig");
        sRtn = f("ExtMdl1.cfg");
        if (!sRtn) {
            GT_SetExtMdlMode f = (GT_SetExtMdlMode)GetProcAddress(hmodule, "GT_SetExtMdlMode");
            sRtn = f(0); // 设置模块的工作方式为独立模式
            if (!sRtn) {
                sRtn = Reset();
            }
        }
    }

    return sRtn;
}

short IOExtension::Close()
{
    GT_CloseExtMdl f = (GT_CloseExtMdl)GetProcAddress(hmodule, "GT_CloseExtMdl");
    return f();
}

short IOExtension::Reset()
{
    GT_ResetExtMdl f = (GT_ResetExtMdl)GetProcAddress(hmodule, "GT_ResetExtMdl");
    return f();
}

short IOExtension::Switch(short card)
{
    GT_SwitchtoCardNoExtMdl f = (GT_SwitchtoCardNoExtMdl)GetProcAddress(hmodule, "GT_SwitchtoCardNoExtMdl");
    return f(card);
}

bool IOExtension::ReadDi(short mdl, short index)
{
    unsigned short value = 0;
    GT_GetExtIoBit f = (GT_GetExtIoBit)GetProcAddress(hmodule, "GT_GetExtIoBit");
    short sRtn = f(mdl, index, &value);
    return !sRtn && (value != 1);
}

short IOExtension::SetDo(short mdl, short index, bool value)
{
    GT_SetExtIoBit f = (GT_SetExtIoBit)GetProcAddress(hmodule, "GT_SetExtIoBit");
    short sRtn = f(mdl, index, value ? 0 : 1);
    return sRtn;
}

 short IOExtension::SetDo(short mdl, short value)
 {
     GT_SetExtIoValue f = (GT_SetExtIoValue)GetProcAddress(hmodule, "GT_SetExtIoValue");
     short sRtn = f(mdl, value);
     return sRtn;
 }