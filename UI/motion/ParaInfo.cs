using System;
using System.Collections.Generic;
using System.Text;

namespace UI.motion
{
    public class ParaInfo
    {
        public int CardID { get; set; }

        public string CardName { get; set; }

        public int AxisID { get; set; }

        public string AxisName { get; set; }

        public bool AxisEnable { get; set; }

        public long AxisPausePerMM { get; set; }

        public long AxisJogAcc { get; set; }

        public long AxisJogDec { get; set; }

        public long AxisJogVel { get; set; }

        public long AixMoveAcc { get; set; }

        public long AxisMoveDec { get; set; }

        public long AxisMoveVel { get; set; }

        public string AxisResetMode { get; set; }

        public string AxisResetDir { get; set; }

        public bool AxisResetSetZero { get; set; }

        public override string ToString()
        {
            return CardID + ", " + CardName + ", " + AxisID + ", " + AxisName + ", " + AxisEnable + ", " + AxisPausePerMM
                 + ", " + AxisJogAcc + ", " + AxisJogDec + ", " + AxisJogVel + ", " + AixMoveAcc + ", " + AxisMoveDec + ", " + AxisMoveVel
                 + ", " + AxisResetMode + ", " + AxisResetDir + ", " + AxisResetSetZero;
        }

        public object[] ToArray()
        {
            return new object[] {
                CardID, CardName, AxisID, AxisName, AxisEnable, AxisPausePerMM,
                AxisJogAcc, AxisJogDec, AxisJogVel, AixMoveAcc, AxisMoveDec, AxisMoveVel,
                AxisResetMode, AxisResetDir, AxisResetSetZero
            };
        }
    }
}
