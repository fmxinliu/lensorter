#ifndef GTSMOTIONPROXY_H
#define GTSMOTIONPROXY_H

#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace msclr::interop;

class GTSMotionClass;
namespace MotionControl {

    public ref class GtsMotionProxy
    {
    public:
        GtsMotionProxy(short cardIdx, short axisNum);
        virtual ~GtsMotionProxy(void);

        bool OpenCard();
        bool CloseCard();

        bool AixOn(short axisIdx);
        bool AixOff(short axisIdx);
        bool LoadConfig(String ^path);
        bool ClearSts(short axisIdx, short count);
        bool SetZeroPos(short axisIdx, short count);
        bool HomeInit();

        bool JogMove(short axisIdx, double speed, double acc, double dec);
        bool P2PMove(short axisIdx, double speed, double acc, double dec, long pos/*pulse*/);
        bool P2PMoveWaitFinished(short axisIdx, double speed, double acc, double dec, long pos/*pulse*/);

        // ∏¥Œª
        bool HomeWithSensor(short axisIdx, double speed, double acc, long pos/*pulse*/, long offset);
        bool GetHomeDone(short axisIdx);

        // Õ£÷π
        bool Stop(short axisIdx);
        bool EmgStop(short axisIdx);

        // IO
        int ReadDi(short port);
        int ReadDo(short port);
        bool SetDo(short port, short value);

        // Œª÷√
        bool ReadAxisPos(short axisIdx, array<double>^ values);
        double ReadAxisPos(short axisIdx);

    private:
        bool SwitchCardNo();
        bool CheckAxisNo(short axisIdx);

    private:
        short m_cardIdx;
        short m_axisNum;
        GTSMotionClass *gts;
    };
}

#endif // GTSMOTIONPROXY_H