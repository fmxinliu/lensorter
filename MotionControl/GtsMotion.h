#pragma once

#include <iostream>
#include <vcclr.h>
#include <msclr/marshal_cppstd.h>
#include "gtsmotionclass.h"

using namespace msclr::interop;
using namespace System;

namespace MotionControl
{
    public ref class GtsMotion
    {
    public:
        GtsMotion(void);
        virtual ~GtsMotion(void);

        void print()
        {
            std::cout << "111";
            Console::WriteLine("123");

            GTSMotionClass gtc;
            gtc.LoadConfig("D:\\新建文件夹\\1.txt");
        }
    };
}

