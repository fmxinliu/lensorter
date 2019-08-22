#ifndef GTSMOTIONPROXY_H
#define GTSMOTIONPROXY_H

#include <iostream>
#include <vcclr.h>
#include <msclr/marshal_cppstd.h>
#using "..\bin\Debug\\SharpConfig.dll"

using namespace System;
using namespace msclr::interop;

class GTSMotionClass;
namespace MotionControl {

    public ref class GtsMotionProxy
    {
    public:
        GtsMotionProxy(void);
        virtual ~GtsMotionProxy(void);

        void print();

    private:
        GTSMotionClass *gts;
        SharpConfig::Configuration ^cfg;
    };
}

#endif // GTSMOTIONPROXY_H