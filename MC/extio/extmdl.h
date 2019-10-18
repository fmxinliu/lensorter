#pragma once

#define IO_API(FUNC) typedef short (__stdcall *FUNC)

#include <Windows.h>

IO_API(GT_OpenExtMdl)(char *pDllName);
IO_API(GT_CloseExtMdl)();
IO_API(GT_SwitchtoCardNoExtMdl)(short card);
IO_API(GT_ResetExtMdl)();
IO_API(GT_LoadExtConfig)(char *pFileName);
IO_API(GT_SetExtIoValue)(short mdl,unsigned short value);
IO_API(GT_GetExtIoValue)(short mdl,unsigned short *pValue);
IO_API(GT_SetExtIoBit)(short mdl,short index,unsigned short value);
IO_API(GT_GetExtIoBit)(short mdl,short index,unsigned short *pValue);
IO_API(GT_GetExtAdValue)(short mdl,short chn,unsigned short *pValue);
IO_API(GT_GetExtAdVoltage)(short mdl,short chn,double *pValue);
IO_API(GT_SetExtDaValue)(short mdl,short chn, unsigned short value);
IO_API(GT_SetExtDaVoltage)(short mdl,short chn,double value);
IO_API(GT_GetStsExtMdl)(short mdl,short chn,unsigned short *pStatus);
IO_API(GT_SetExtMdlMode)(short mode);
IO_API(GT_GetExtMdlMode)(short *pMode);