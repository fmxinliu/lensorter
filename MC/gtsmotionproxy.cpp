#include "stdafx.h"
#include "gtsmotionproxy.h"
#include "gtsmotionclass.h"
#include "ioextension.h"
#include <iostream>

using namespace MC;
using namespace std;

GTSMotionProxy::GTSMotionProxy(int cardIdx, int axisNum, int extmdlNum)
    : m_cardIdx(cardIdx), m_axisNum(axisNum), gts(new GTSMotionClass)
{
    if (m_cardIdx < 0) {
        throw gcnew Exception("运动卡号 < 0");
    }

    io = extmdlNum > 0 ? new IOExtension() : NULL;

    if (object == nullptr) {
        object = gcnew Object;
    }
}

GTSMotionProxy::~GTSMotionProxy(void)
{
    delete io; io = NULL;
    delete gts; gts = NULL;
}

// 获取同步锁
void GTSMotionProxy::Lock()
{
    Monitor::Enter(object);
}

// 释放同步锁
void GTSMotionProxy::Unlock()
{
    Monitor::Exit(object);
}

bool GTSMotionProxy::SwitchCardNo()
{
    bool ret = true;
    short idx;
    int cardIdx = gts->GetCardNo(&idx) ? -1 : idx;
    if (cardIdx >= 0 && cardIdx != m_cardIdx) {
        ret = !gts->SetCardNo(m_cardIdx);
    }
    return ret;
}

bool GTSMotionProxy::OpenCard()
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->OpenCard() && Stop();
    if (!ret) {
        printf("Card Open Fail");
    }

    if (ret && io && io->Open()) {
        ret = false;
        printf("IOExtense Open Fail");
    }
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::CloseCard()
{
    this->Lock();
    bool ret = SwitchCardNo() && Stop() && !gts->CloseCard();
    if (ret && io && io->Close()) {
        ret = false;
        printf("IOExtense Close Fail");
    }
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::AixOn(int axisIdx)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->AixOn(axisIdx);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::AixOff(int axisIdx)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->AixOff(axisIdx);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::LoadConfig(String ^path)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->LoadConfig(marshal_as<string>(path));
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::ClearSts(int axisIdx, int count)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->ClearSts(axisIdx, count);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::SetZeroPos(int axisIdx, int count)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->SetZeroPos(axisIdx, count);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::HomeInit()
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->HomeInit();
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::JogMove(int axisIdx, double speed, double acc, double dec)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->JogMove(axisIdx, speed, acc, dec, 0.8);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::P2PMove(int axisIdx, double speed, double acc, double dec, long pos)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->P2PMove(axisIdx, pos, speed, acc, dec, 1);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::P2PMoveWaitFinished(int axisIdx, double speed, double acc, double dec, long pos)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->P2PMoveWaitFinished(axisIdx, pos, speed, acc, dec, 1);
    this->Unlock();
    return ret;
}

// 复位
bool GTSMotionProxy::HomeWithSensor(int axisIdx, double speed, double acc, long pos, long offset)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->HomeWithSensor(axisIdx, pos, speed, acc, 0);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::GetHomeDone(int axisIdx)
{
    this->Lock();
    bool ret = SwitchCardNo() && gts->GetHomeDone(axisIdx);
    this->Unlock();
    return ret;
}

// 停止
bool GTSMotionProxy::Stop()
{
    this->Lock();
    bool ret = SwitchCardNo();
    if (ret) {
        gts->StopMultiMove(m_axisNum);
    }
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::Stop(int axisIdx)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->StopMove(axisIdx, 0);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::EmgStop(int axisIdx)
{
    this->Lock();
    bool ret = SwitchCardNo() && !gts->StopMove(axisIdx, 1);
    this->Unlock();
    return ret;
}

// IO
bool GTSMotionProxy::ReadDi(int port)
{
    this->Lock();
    bool ret = SwitchCardNo() && gts->ReadDi(port);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::ReadDo(int port)
{
    this->Lock();
    bool ret = SwitchCardNo() && gts->ReadDo(port);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::SetDo(int port, bool value)
{
   this->Lock();
   bool ret = SwitchCardNo() && !gts->SetDo(port, value);
   this->Unlock();
   return ret;
}

bool GTSMotionProxy::ReadDi(int mdl, int port)
{
    this->Lock();
    bool ret = SwitchCardNo() && io && io->ReadDi(mdl, port);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::SetDo(int mdl, int port, bool value)
{
    this->Lock();
    bool ret = SwitchCardNo() && io && !io->SetDo(mdl, port, value);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::SetDo(int mdl, int value)
{
    this->Lock();
    bool ret = SwitchCardNo() && io && !io->SetDo(mdl, value);
    this->Unlock();
    return ret;
}

bool GTSMotionProxy::ReadAxisPos(int axisIdx, array<double>^ values)
{
    this->Lock();
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

    this->Unlock();
    return ret;
}

double GTSMotionProxy::ReadAxisPos(int axisIdx)
{
    this->Lock();
    double pos = 0;
    if (SwitchCardNo()) {
        gts->ReadEncodePos(axisIdx, 1, &pos);
    }
    this->Unlock();
    return pos;
}