#include "stdafx.h"
#include "motionparam.h"


MotionParam::MotionParam(PRA_GTS_ID_ENUM gts_id) : pConfig(NULL)
{
    if (GTS_400 == gts_id) {

    } else if (GTS_800 == gts_id) {

    } else {

        throw "不支持的运动卡类型";
    }

    int axisNum = (GTS_400 == gts_id) ? 4 : 8;
    std::string name = (GTS_400 == gts_id) ? "GTS_400" : "GTS_800";

    pConfig = new MotionConfig();
    pConfig->mCardName = name;
    pConfig->mAixParaArry.resize(axisNum, new AIX_PARA[axisNum]);
    pConfig->mMotorSpeedArry.resize(axisNum, new MOTOR_SPEED[axisNum * 4]);
}

MotionParam::MotionParam(PRA_GTS_ID_ENUM gts_id, MotionConfig *pConfig) : pConfig(NULL)
{
    if (GTS_400 == gts_id) {

    } else if (GTS_800 == gts_id) {

    } else {

        throw "不支持的运动卡类型";
    }

    int axisNum = (GTS_400 == gts_id) ? 4 : 8;
    std::string name = (GTS_400 == gts_id) ? "GTS_400" : "GTS_800";

    this->pConfig = pConfig;
    pConfig->mCardName = name;
}

MotionParam::MotionParam(std::string configPath)
{
}

MotionParam::~MotionParam()
{
    if (pConfig)
    {
        for (int i = 0; i < pConfig->mAixParaArry.size(); i++)
        {
            delete [] pConfig->mAixParaArry[i];
        }

        for (int i = 0; i < pConfig->mMotorSpeedArry.size(); i++)
        {
            delete [] pConfig->mMotorSpeedArry[i];
        }

        pConfig->mCardName.clear();
        pConfig->mAixParaArry.clear();
        pConfig->mMotorSpeedArry.clear();

        delete pConfig; pConfig = NULL;
    }
}

AIX_PARA* MotionParam::getAixPara(int aixs)
{
    if (aixs >= 0 && aixs < pConfig->mAixParaArry.size())
    {
        return pConfig->mAixParaArry[aixs];
    }

    return NULL;
}

MOTOR_SPEED* MotionParam::getMotorSpeed(int aixs, int speedType)
{
    if (aixs >= 0)
    {
        int id = aixs * 4 + speedType;
        if (id >= 0 && id < pConfig->mMotorSpeedArry.size()) {
            return pConfig->mMotorSpeedArry[aixs * 4 + speedType];
        }
    }

    return NULL;
}