#include "StdAfx.h"
#include "test.h"

using namespace MotionControl;

#pragma region 易错
const char* Test::StringToChars(String ^s)
{
    std::string s1 = marshal_as<std::string>(s); // OK
    const char* str = marshal_as<std::string>(s).c_str(); // FAIL !!!
    return str;
}
#pragma endregion

int Test::StringToInt(String ^s)
{
    // marshal_as当返回的对象需要显式内存清理时，就需要基于marshal_context上下文的封送了
    marshal_context ^mc = gcnew marshal_context();
    const char* str = mc->marshal_as<const char*>(s);
    int value = _ttoi(str);
    delete mc;  // 当marshal_context删除后，任何在封送调用期间分配的内存都将被释放
    return value;
}

double Test::StringToDouble(String ^s)
{
    IntPtr ip = Marshal::StringToHGlobalAnsi(s); // 转为非托管内存
    const char* str = static_cast<const char*>(ip.ToPointer());
    double value = _ttof(str);
    Marshal::FreeHGlobal(ip); // 释放内存
    return value;
}
