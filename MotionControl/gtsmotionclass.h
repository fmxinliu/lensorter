#ifndef GTSMOTIONCLASS_H
#define GTSMOTIONCLASS_H

#include <string>

class GTSMotionClass
{
public:
	GTSMotionClass(void);
	virtual ~GTSMotionClass(void);

public:
	short OpenCard();
	short CloseCard();
	short ResetCard();
    short GetCardNo();
    short SetCardNo(short index); // 切换当前运动控制器卡号

    short AixOn(short index);
    short AixOff(short index);
    short AixON(int nCount);
    short AixOFF(int nCount);
    short LoadConfig(std::string mConfigPath);
	short ClearSts(int startAix, int nCount); // 清除驱动器报警标志
	short SetZeroPos(int startAix, int nCount); // 清零规划位置和实际位置
	short HomeInit(); // 初始化自动回原点功能

	short JogMove(int nAixID, int nSpeed, double nACC, double nDEC, double nSmooth);
	short P2PMove(int nAixID, long pos/*pulse*/, int nSpeed, double nACC, double nDEC, double nSmoothTime);
    short P2PMoveWaitFinished(int nAixID, long pos/*pulse*/, int nSpeed, double nACC, double nDEC, double nSmoothTime);

    // 复位
	short HomeWithSensor(int axisID, double pos, double nSpeed, double nACC, double offset=0);
	bool GetHomeDone(int axisID);

    // 停止
	short StopMove(int mask, int mode);
    void StopMultiMove(int nAixNum);
    void EmgMultiMove(int nAixNum);
    bool GetEmgStatus(int axisID) ;

    // IO
    int ReadDI(int port);
    int ReadDO(int port);
	short SetDO(int port, int value);

    double* GTSMotionClass::ReadEncodePos(int nStartInex, int nCount); // 读取编码器位置
};

#endif // GTSMOTIONCLASS_H

