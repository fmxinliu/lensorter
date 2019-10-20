#ifndef GTSMOTIONPROXY_H
#define GTSMOTIONPROXY_H

#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace msclr::interop;

class IOExtension;
class GTSMotionClass;
namespace MC {

    public ref class GTSMotionProxy
    {
    public:
        GTSMotionProxy(short cardIdx, short axisNum, short extmdlNum);
        virtual ~GTSMotionProxy(void);

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

        // 复位
        bool HomeWithSensor(short axisIdx, double speed, double acc, long pos/*pulse*/, long offset);
        bool GetHomeDone(short axisIdx);

        // 停止
        bool Stop();
        bool Stop(short axisIdx);
        bool EmgStop(short axisIdx);

        // IO
        bool ReadDi(short port);
        bool ReadDo(short port);
        bool SetDo(short port, bool value);

        // 扩展 IO
        bool ReadDi(short mdl, short port);
        bool SetDo(short mdl, short port, bool value);
        bool SetDo(short mdl, int value);

        // 位置
        bool ReadAxisPos(short axisIdx, array<double>^ values);
        double ReadAxisPos(short axisIdx);

    private:
        bool SwitchCardNo();

    private:
        short m_cardIdx;
        short m_axisNum;
        GTSMotionClass *gts;
        IOExtension *io;
    };
}

#endif // GTSMOTIONPROXY_H