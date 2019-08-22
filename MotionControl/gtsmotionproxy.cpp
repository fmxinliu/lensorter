#include "stdafx.h"
#include "gtsmotionproxy.h"
#include "gtsmotionclass.h"

using namespace MotionControl;

GtsMotionProxy::GtsMotionProxy(void)
{
    gts = new GTSMotionClass; 
    cfg = gcnew SharpConfig::Configuration;
}


GtsMotionProxy::~GtsMotionProxy(void)
{
    delete gts;
}


void GtsMotionProxy::print()
{
    std::cout << "111";
    Console::WriteLine("123");

    gts->LoadConfig("D:\\新建文件夹\\1.txt");
}