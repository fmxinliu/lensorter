#include "stdafx.h"
#include "gtsmotionclass.h"
#include "gts.h"

using namespace std;

GTSMotionClass::GTSMotionClass(void)
{
}

GTSMotionClass::~GTSMotionClass(void)
{
}

short GTSMotionClass::OpenCard()
{
    short sRtn = GT_Open(0,0);
    return 0;
}

short GTSMotionClass::CloseCard()
{
    return GT_Close();
}

short GTSMotionClass::ResetCard()
{
    return GT_Reset();
}

short GTSMotionClass::GetCardNo(short *index)
{
    return GT_GetCardNo(index); // [0, 15]
}

short GTSMotionClass::SetCardNo(short index)
{
    return GT_SetCardNo(index);
}

short GTSMotionClass::AixOn(short index)
{
    return GT_AxisOn(index + 1);
}

short GTSMotionClass::AixOff(short index)
{
    return GT_AxisOff(index + 1);
}

short GTSMotionClass::AixON(int nCount)
{
    short sRtn = 0;
    for(int i = 0; i < nCount; i++)
    {
        sRtn = GT_AxisOn(i + 1);
    }

    return sRtn;
}

short GTSMotionClass::AixOFF(int nCount)
{
    short sRtn=0;
    for(int i = 0; i < nCount; i++)
    {
        sRtn = GT_AxisOff(i + 1);
    }

    return sRtn;
}

short GTSMotionClass::LoadConfig(std::string mConfigPath)
{
    puts(mConfigPath.c_str());
    return GT_LoadConfig((char *)mConfigPath.c_str());
}

short GTSMotionClass::ClearSts(int startAix, int nCount)
{
    return GT_ClrSts(startAix, nCount);
}

short GTSMotionClass::SetZeroPos(int startAix, int nCount)
{
    return GT_ZeroPos(startAix , nCount);
}

short GTSMotionClass::HomeInit()
{
    return GT_HomeInit();
}

short GTSMotionClass::JogMove(int nAixID, double nSpeed, double nACC, double nDEC, double nSmooth)
{
    nAixID += 1;
    short sRtn = 0;
    TJogPrm jog;
    if(nSmooth >= 1)
        nSmooth=0.8;

    // 将AXIS轴设为Jog模式
    sRtn = GT_PrfJog(nAixID);
    // 读取Jog运动参数
    sRtn = GT_GetJogPrm(nAixID, &jog);
    jog.acc = nACC;
    jog.dec = nDEC;
    jog.smooth = nSmooth;
    // 设置Jog运动参数
    sRtn = GT_SetJogPrm(nAixID, &jog);
    // 设置AXIS轴的目标速度
    sRtn = GT_SetVel(nAixID, nSpeed);
    // 启动AXIS轴的运动
    sRtn = GT_Update(1<<(nAixID-1));
    return sRtn;
}

short GTSMotionClass::P2PMove(int nAixID, long pos, double nSpeed, double nACC, double nDEC, short nSmoothTime)
{
    nAixID += 1;
    TTrapPrm trap;
    short sRtn=0;
    // 将AXIS轴设为点位模式
    sRtn = GT_PrfTrap(nAixID);
    sRtn = GT_GetTrapPrm(nAixID, &trap);
    trap.acc = nACC;
    trap.dec = nDEC;
    trap.smoothTime = nSmoothTime;
    // 设置点位运动参数
    sRtn = GT_SetTrapPrm(nAixID, &trap);
    // 设置AXIS轴的目标位置
    sRtn = GT_SetPos(nAixID, pos);
    // 设置AXIS轴的目标速度
    sRtn = GT_SetVel(nAixID, nSpeed);
    // 启动AXIS轴的运动
    sRtn = GT_Update(1<<(nAixID-1));
    long sts;
    //double prfPos;
    //do
    //{
    //// 读取AXIS轴的状态
    sRtn = GT_GetSts(nAixID, &sts);
    //// 读取AXIS轴的规划位置
    //sRtn = GT_GetPrfPos(nAixID, &prfPos);
    ////printf("sts=0x%-10lxprfPos=%-10.1lf\r", sts, prfPos);
    //}while(sts&0x400); // 等待AXIS轴规划停止
    return sRtn;
}

short GTSMotionClass::P2PMoveWaitFinished(int nAixID, long pos, double nSpeed, double nACC, double nDEC, short nSmoothTime)
{
    nAixID += 1;
    TTrapPrm trap;
    short sRtn=0;
    // 将AXIS轴设为点位模式
    sRtn = GT_PrfTrap(nAixID);
    sRtn = GT_GetTrapPrm(nAixID, &trap);
    trap.acc = nACC;
    trap.dec = nDEC;
    trap.smoothTime = nSmoothTime;
    // 设置点位运动参数
    sRtn = GT_SetTrapPrm(nAixID, &trap);
    // 设置AXIS轴的目标位置
    sRtn = GT_SetPos(nAixID, pos);
    // 设置AXIS轴的目标速度
    sRtn = GT_SetVel(nAixID, nSpeed);
    // 启动AXIS轴的运动
    sRtn = GT_Update(1<<(nAixID-1));
    long sts;
    double prfPos;

    do
    {
        // 读取AXIS轴的状态
        sRtn = GT_GetSts(nAixID, &sts);
        // 读取AXIS轴的规划位置
        sRtn = GT_GetPrfPos(nAixID, &prfPos);

    } while(sts&0x400); // 等待AXIS轴规划停止

    return sRtn;
}

short GTSMotionClass::HomeWithSensor(int axisID, long pos, double nSpeed, double nACC, long offset)
{
    short sRtn = GT_Home(axisID + 1, pos, nSpeed, nACC, offset);
    unsigned short sts = 0;
    int k = 500;
    int i = 0;
    for(i = 0; i < k; i++)
    {
        GT_HomeSts(axisID + 1, &sts);
        SleepEx(20, FALSE);
        if(sts == 1)
            return 0;
    }
    if(i > k - 3) return -1;
  /*  while(sts != 1 && !kbhit())
    {
        GT_HomeSts(axisID + 1, &sts);
        Sleep(20);
    }*/
    return sRtn;
}

bool GTSMotionClass::GetHomeDone(int axisID)
{
    unsigned short pStatus=0;
    GT_HomeSts(axisID + 1, &pStatus);
    if(pStatus >= 1)
        return true;
    return false;
}

short GTSMotionClass::ReadEncodePos(int nStartInex, int nCount, double *pos)
{
    memset(pos, 0, sizeof(double)*nCount);
    short sRtn = GT_GetEncPos(nStartInex, pos, nCount);
    return sRtn;
}

short GTSMotionClass::SetDo(short port, bool value)
{
    short sRtn = GT_SetDoBit(MC_GPO, port + 1, value);
    return sRtn;
}

bool GTSMotionClass::ReadDo(short port)
{
    long nValue=0;
    GT_GetDo(MC_GPO, &nValue);  // 通用输出
    long nResult = nValue & (1 << port);
    return (nResult >> port) != 0;
}

bool GTSMotionClass::ReadDi(short port)
{
    long nValue=0;
    GT_GetDi(MC_GPI, &nValue);  // 通用输入
    long nResult = nValue & (1 << port);
    return (nResult >> port) != 0;
}

bool GTSMotionClass::GetEmgStatus(int axisID) 
{
    long ReturnNumber= 0;
    GT_GetDi(MC_ALARM, &ReturnNumber); // 驱动报警

    int nResult = ReturnNumber & (1<<(7));
    if (nResult != 0)
    {
        return false;
    }
    else
    {
        return true;
    }
}

short GTSMotionClass::StopMove(int mask, int mode)
{
    int axis_num = (1 << mask);
    return GT_Stop(axis_num, mode); // 0:平滑停止  1:急停
}

void GTSMotionClass::StopMultiMove(int nAixNum)
{
    for(int i=0; i<nAixNum; i++)
    {
        StopMove(i, 0);
    }
}

void GTSMotionClass::EmgMultiMove(int nAixNum)
{
    for(int i=0; i<nAixNum; i++)
    {
        StopMove(i, 1);
    }
}
