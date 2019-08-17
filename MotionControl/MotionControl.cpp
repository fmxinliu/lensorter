// MotionControl.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "gtsmotionclass.h"

int _tmain(int argc, _TCHAR* argv[])
{
    GTSMotionClass gmc;
    printf("Open: %d\n", gmc.OpenCard());

    system("pause");
	return 0;
}

