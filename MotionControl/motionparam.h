#ifndef MOTIONPARAM_H
#define MOTIONPARAM_H

#include <string>
#include <vector>

// 运动卡编号
enum PRA_GTS_ID_ENUM
{
    GTS_400,
    GTS_800,
};

// 运动轴编号
enum PRA_AXIS_ID_ENUM
{
    A1, A2, A3, A4,
    A5, A6, A7, A8, A9, A10, A11, A12,
};

//// 
//struct MYPOINT5F
//{
//    float 
//    MYPOINT5F()
//    {
//        X=Y=Z=R=T=0;
//    }
//};

enum PRA_SPEED_TYPE_ENUM
{
    RESET,
    JOG,
    MOVE,
    AUTO,
};

// 轴速度
struct MOTOR_SPEED
{
    std::string nName;
    double VM, DEC, ACC, smooth;
    MOTOR_SPEED()
    {
        nName="";
        VM = DEC = ACC = smooth = 0.0;
    }
};

// 轴参数
struct AIX_PARA
{
    int nAixID;
    std::string nName;
    int enable; // 轴的状态
    double mm_per_plues;// 脉冲分辨率  10.0/10000;//单位MM   10是导轨的导程   10000为脉冲数
    double GrateRulerAccuracy; // 光栅尺精度
    int nHomeMode, nHomeDir;

    AIX_PARA()
    {
        nAixID = 0;
        nName = "Aix";
        enable = false;
        mm_per_plues = 0.0;
        GrateRulerAccuracy = 0.0;
        nHomeDir = 0;
        nHomeMode = 0;
    }
};

struct IOPortStruct
{
    std::string mCardName;
    std::string nPortName;
    int nPortID;
    int enable;
    int dir;
};

// 整个运动卡的参数
struct MotionConfig
{
    std::string mCardName;
    std::vector<AIX_PARA*> mAixParaArry;
    std::vector<MOTOR_SPEED*> mMotorSpeedArry;
    std::string mConfigPath;
    bool Enable;
};

class MotionParam
{
public:
    MotionParam(PRA_GTS_ID_ENUM gts_id);
    MotionParam(PRA_GTS_ID_ENUM gts_id, MotionConfig *pConfig);
    MotionParam(std::string configPath);
    ~MotionParam(); 

    AIX_PARA* getAixPara(int aixs);
    MOTOR_SPEED* getMotorSpeed(int aixs, int speedType);

private:
    MotionConfig* pConfig;
};

#endif // MOTIONPARAM_H