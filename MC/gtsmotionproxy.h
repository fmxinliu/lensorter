#ifndef GTSMOTIONPROXY_H
#define GTSMOTIONPROXY_H

#include <msclr\marshal_cppstd.h>

using namespace System;
using namespace msclr::interop;
using namespace System::Threading;

class IOExtension;
class GTSMotionClass;
namespace MC {

    public ref class GTSMotionProxy
    {
    public:
        GTSMotionProxy(int cardIdx, int axisNum, int extmdlNum);
        virtual ~GTSMotionProxy(void);

        bool OpenCard();
        bool CloseCard();

        bool AixOn(int axisIdx);
        bool AixOff(int axisIdx);
        bool LoadConfig(String ^path);
        bool ClearSts(int axisIdx, int count);
        bool SetZeroPos(int axisIdx, int count);
        bool HomeInit();

        bool JogMove(int axisIdx, double speed, double acc, double dec);
        bool P2PMove(int axisIdx, double speed, double acc, double dec, long pos/*pulse*/);
        bool P2PMoveWaitFinished(int axisIdx, double speed, double acc, double dec, long pos/*pulse*/);

        // 复位
        bool HomeWithSensor(int axisIdx, double speed, double acc, long pos/*pulse*/, long offset);
        bool GetHomeDone(int axisIdx);

        // 停止
        bool Stop();
        bool Stop(int axisIdx);
        bool EmgStop(int axisIdx);

        // IO
        bool ReadDi(int port);
        bool ReadDo(int port);
        bool SetDo(int port, bool value);

        // 扩展 IO
        bool ReadDi(int mdl, int port);
        bool SetDo(int mdl, int port, bool value);
        bool SetDo(int mdl, int value);

        // 位置
        bool ReadAxisPos(int axisIdx, array<double>^ values);
        double ReadAxisPos(int axisIdx);

    private:
        bool SwitchCardNo();
        void Lock();
        void Unlock();

    private:
        int m_cardIdx;
        int m_axisNum;
        GTSMotionClass *gts;
        IOExtension *io;
        static Object ^object;
    };
}

#endif // GTSMOTIONPROXY_H