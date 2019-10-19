#include "stdafx.h"
#include "gtsmotionproxy.h"
#include "gtsmotionclass.h"
#include "ioextension.h"
#include <iostream>

using namespace MC;
using namespace std;

GTSMotionProxy::GTSMotionProxy(short cardIdx, short axisNum, short extmdlNum)
    : m_cardIdx(cardIdx), m_axisNum(axisNum), gts(new GTSMotionClass)
{
    if (m_cardIdx < 0) {
        throw gcnew Exception("运动卡号 < 0");
    }

    io = extmdlNum > 0 ? new IOExtension() : NULL;
}

GTSMotionProxy::~GTSMotionProxy(void)
{
    delete io; io = NULL;
    delete gts; gts = NULL;
}

bool GTSMotionProxy::SwitchCardNo()
{
    bool ret = true;
    short cardIdx = gts->GetCardNo(&cardIdx) ? -1 : cardIdx;
    if (cardIdx >= 0 && cardIdx != m_cardIdx) {
        ret = !gts->SetCardNo(m_cardIdx);
    }
    return ret;
}

bool GTSMotionProxy::OpenCard()
{
    bool ret = SwitchCardNo() && !gts->OpenCard();
    if (!ret) {
        printf("Card Open Fail");
    }

    if (ret && io && io->Open()) {
        ret = false;
        printf("IOExtense Open Fail");
    }

    return ret;
}

bool GTSMotionProxy::CloseCard()
{
    return SwitchCardNo() && Stop() && !gts->CloseCard();
}

bool GTSMotionProxy::AixOn(short axisIdx)
{
    return SwitchCardNo() && !gts->AixOn(axisIdx);
}

bool GTSMotionProxy::AixOff(short axisIdx)
{
    return SwitchCardNo() && !gts->AixOff(axisIdx);
}

bool GTSMotionProxy::LoadConfig(String ^path)
{
    return SwitchCardNo() && !gts->LoadConfig(marshal_as<string>(path));
}

bool GTSMotionProxy::ClearSts(short axisIdx, short count)
{
    return SwitchCardNo() && !gts->ClearSts(axisIdx, count);
}

bool GTSMotionProxy::SetZeroPos(short axisIdx, short count)
{
    return SwitchCardNo() && !gts->SetZeroPos(axisIdx, count);
}

bool GTSMotionProxy::HomeInit()
{
    return SwitchCardNo() && !gts->HomeInit();
}

bool GTSMotionProxy::JogMove(short axisIdx, double speed, double acc, double dec)
{
    return SwitchCardNo() && !gts->JogMove(axisIdx, speed, acc, dec, 0.8);
}

bool GTSMotionProxy::P2PMove(short axisIdx, double speed, double acc, double dec, long pos)
{
    return SwitchCardNo() && !gts->P2PMove(axisIdx, pos, speed, acc, dec, 1);
}

bool GTSMotionProxy::P2PMoveWaitFinished(short axisIdx, double speed, double acc, double dec, long pos)
{
    return SwitchCardNo() && !gts->P2PMoveWaitFinished(axisIdx, pos, speed, acc, dec, 1);
}

// 复位
bool GTSMotionProxy::HomeWithSensor(short axisIdx, double speed, double acc, long pos, long offset)
{
    return SwitchCardNo() && !gts->HomeWithSensor(axisIdx, pos, speed, acc, 0);
}

bool GTSMotionProxy::GetHomeDone(short axisIdx)
{
    return SwitchCardNo() && gts->GetHomeDone(axisIdx);
}

// 停止
bool GTSMotionProxy::Stop()
{
    bool ret = SwitchCardNo();
    if (ret) {
        gts->StopMultiMove(m_axisNum);
    }
    return ret;
}

bool GTSMotionProxy::Stop(short axisIdx)
{
    return SwitchCardNo() && !gts->StopMove(axisIdx, 0);
}

bool GTSMotionProxy::EmgStop(short axisIdx)
{
    return SwitchCardNo() && !gts->StopMove(axisIdx, 1);
}

// IO
bool GTSMotionProxy::ReadDi(short port)
{
    return SwitchCardNo() && gts->ReadDi(port);
}

bool GTSMotionProxy::ReadDo(short port)
{
    return SwitchCardNo() && gts->ReadDo(port);
}

bool GTSMotionProxy::SetDo(short port, bool value)
{
   return SwitchCardNo() && !gts->SetDo(port, value);
}
//bool GTSMotionProxy::ReadDi(short port)
//{
//    // 0-15  卡
//    // 16-31 模块1
//    // 32-47 模块2
//    // 48-63 模块3
//    // 64-79 模块4
//    bool value = false;
//    if (SwitchCardNo()) {
//        value = (port < 16) ? gts->ReadDi(port) : io->ReadDi(port / 16 - 1, port % 16);
//    }
//    return value;
//}
//
//bool GTSMotionProxy::ReadDo(short port)
//{
//    bool value = false;
//    if (SwitchCardNo()) {
//        if (port >= 0 && port < 16) {
//            value = gts->ReadDo(port);
//        } else {
//            throw gcnew Exception("无法获取扩展模块输出端口值");
//        }
//    }
//    return value;
//}
//
//bool GTSMotionProxy::SetDo(short port, bool value)
//{
//    bool ret = false;
//    if (SwitchCardNo()) {
//        ret = (port < 16) ? !gts->SetDo(port, value) : !io->SetDo(port / 16 - 1, port % 16, value);
//    }
//    return ret;
//}

bool GTSMotionProxy::ReadDi(short mdl, short port)
{
    return SwitchCardNo() && io && io->ReadDi(mdl, port);
}

bool GTSMotionProxy::SetDo(short mdl, short port, bool value)
{
    return SwitchCardNo() && io && !io->SetDo(mdl, port, value);
}

bool GTSMotionProxy::ReadAxisPos(short axisIdx, array<double>^ values)
{
    bool ret = false;
    if (SwitchCardNo()) {
        int count = values->Length;
        pin_ptr<double> pos = &values[0]; //  pin_ptr<> 固定数组，当本机代码执行并访问数组数据时,垃圾收集器无法回收
        ret = !gts->ReadEncodePos(axisIdx, count, pos);
        //double *pos = new double[count];
        //memset(pos, 0, sizeof(double)*nCount);
        //gts->ReadEncodePos(axisIdx, pos);
        //for (int i = 0; i < count; i++) {
        //    values[i] = pos[i];
        //}
        //delete []pos;
    }

    return ret;
}

double GTSMotionProxy::ReadAxisPos(short axisIdx)
{
    double pos = 0;
    if (SwitchCardNo()) {
        gts->ReadEncodePos(axisIdx, 1, &pos);
    }

    return pos;
}