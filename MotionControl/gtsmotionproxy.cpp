#include "stdafx.h"
#include "gtsmotionproxy.h"
#include "gtsmotionclass.h"
#include <iostream>

using namespace std;
using namespace MotionControl;

GtsMotionProxy::GtsMotionProxy(short cardIdx, short axisNum)
    : m_cardIdx(cardIdx), m_axisNum(axisNum), gts(new GTSMotionClass)
{
    if (m_cardIdx < 0) {
        throw gcnew Exception("运动卡号 < 0");
    }

    if (!(axisNum > 0 && axisNum <= 8)) {
        throw gcnew Exception("运动卡轴数{1-8}超出范围");
    }
}

GtsMotionProxy::~GtsMotionProxy(void)
{
    delete gts;
}

bool GtsMotionProxy::CheckAxisNo(short axisIdx)
{
    return (axisIdx >= 0 && axisIdx < m_axisNum);
}

bool GtsMotionProxy::SwitchCardNo()
{
    bool ret = true;
    short cardIdx = gts->GetCardNo(&cardIdx) ? -1 : cardIdx;
    if (cardIdx >= 0 && cardIdx != m_cardIdx) {
        ret = !gts->SetCardNo(m_cardIdx);
    }
    return ret;
}

bool GtsMotionProxy::OpenCard()
{
    return SwitchCardNo() && !gts->OpenCard();
}

bool GtsMotionProxy::CloseCard()
{
    return SwitchCardNo() && !gts->CloseCard();
}

bool GtsMotionProxy::AixOn(short axisIdx)
{
    return SwitchCardNo() && !gts->AixOn(axisIdx);
}

bool GtsMotionProxy::AixOff(short axisIdx)
{
    return SwitchCardNo() && !gts->AixOff(axisIdx);
}

bool GtsMotionProxy::LoadConfig(String ^path)
{
    return SwitchCardNo() && !gts->LoadConfig(marshal_as<string>(path));
}

bool GtsMotionProxy::ClearSts(short axisIdx, short count)
{
    return SwitchCardNo() && !gts->ClearSts(axisIdx, count);
}

bool GtsMotionProxy::SetZeroPos(short axisIdx, short count)
{
    return SwitchCardNo() && !gts->SetZeroPos(axisIdx, count);
}

bool GtsMotionProxy::HomeInit()
{
    return SwitchCardNo() && !gts->HomeInit();
}

bool GtsMotionProxy::JogMove(short axisIdx, double speed, double acc, double dec)
{
    return SwitchCardNo() && !gts->JogMove(axisIdx, speed, acc, dec, 0.8);
}

bool GtsMotionProxy::P2PMove(short axisIdx, double speed, double acc, double dec, long pos)
{
    return SwitchCardNo() && !gts->P2PMove(axisIdx, pos, speed, acc, dec, 1);
}

bool GtsMotionProxy::P2PMoveWaitFinished(short axisIdx, double speed, double acc, double dec, long pos)
{
    return SwitchCardNo() && !gts->P2PMoveWaitFinished(axisIdx, pos, speed, acc, dec, 1);
}

// 复位
bool GtsMotionProxy::HomeWithSensor(short axisIdx, double speed, double acc, long pos, long offset)
{
    return SwitchCardNo() && !gts->HomeWithSensor(axisIdx, pos, speed, acc, 0);
}

bool GtsMotionProxy::GetHomeDone(short axisIdx)
{
    return SwitchCardNo() && gts->GetHomeDone(axisIdx);
}

// 停止
bool GtsMotionProxy::Stop(short axisIdx)
{
    return SwitchCardNo() && !gts->StopMove(axisIdx, 0);
}

bool GtsMotionProxy::EmgStop(short axisIdx)
{
    return SwitchCardNo() && !gts->StopMove(axisIdx, 1);
}

// IO
int GtsMotionProxy::ReadDi(short port)
{
    int value = SwitchCardNo() ? gts->ReadDI(port) : 0;
    return value;
}

int GtsMotionProxy::ReadDo(short port)
{
    int value = SwitchCardNo() ? gts->ReadDO(port) : 0;
    return value;
}

bool GtsMotionProxy::SetDo(short port, short value)
{
    return SwitchCardNo() && !gts->SetDO(port, value);
}

bool GtsMotionProxy::ReadAxisPos(short axisIdx, array<double>^ values)
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

double GtsMotionProxy::ReadAxisPos(short axisIdx)
{
    double pos = 0;
    if (SwitchCardNo()) {
        gts->ReadEncodePos(axisIdx, 1, &pos);
    }

    return pos;
}