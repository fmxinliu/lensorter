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
    short rtn = f("gts.dll");

    if (!rtn) {
        GT_LoadExtConfig f = (GT_LoadExtConfig)GetProcAddress(hmodule, "GT_LoadExtConfig");
        rtn = f("ExtMdl1.cfg");
        if (!rtn) {
            GT_SetExtMdlMode f = (GT_SetExtMdlMode)GetProcAddress(hmodule, "GT_SetExtMdlMode");
            rtn = f(1); // 设置模块的工作方式为内部模式
            if (!rtn) {
                rtn = Reset();
            }
        }
    }

    return rtn;
}

short IOExtension::Close()
{
    GT_CloseExtMdl f = (GT_CloseExtMdl)GetProcAddress(hmodule, "GT_OpenExtMdl");
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

short IOExtension::ReadDi(short mdl,short index, unsigned short *pValue)
{
    GT_GetExtIoBit f = (GT_GetExtIoBit)GetProcAddress(hmodule, "GT_GetExtIoBit");
    return f(mdl, index, pValue);
}

short IOExtension::SetDo(short mdl, short index, unsigned short value)
{
    GT_SetExtIoBit f = (GT_SetExtIoBit)GetProcAddress(hmodule, "GT_SetExtIoBit");
    return f(mdl, index, value);
}