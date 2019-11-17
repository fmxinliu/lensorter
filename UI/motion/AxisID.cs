using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.motion
{
    public class Axis
    {
        /// <summary>
        /// 卡1编号
        /// </summary>
        public static int GTS400 = 0;

        /// <summary>
        /// 卡2编号
        /// </summary>
        public static int GTS800 = 1;

        /// <summary>
        /// 水平移动仓（左+）
        /// </summary>
        public static int ProductMoveX = 0;

        /// <summary>
        /// 垂直移动仓（下+）
        /// </summary>
        public static int ProductMoveZ = 1;

        /// <summary>
        /// 1号皮带（左+）
        /// </summary>
        public static int LensMoveX1 = 2;

        /// <summary>
        /// 2号皮带（左+）
        /// </summary>
        public static int LensMoveX2 = 3;

        /// <summary>
        /// 卡1轴数
        /// </summary>
        public static int GTS400Total = 4;

        /// <summary>
        /// 3号皮带（上+）
        /// </summary>
        public static int LensMoveY3 = 0;

        /// <summary>
        /// 4号皮带（右+）
        /// </summary>
        public static int LensMoveX4 = 1;

        /// <summary>
        /// 5号皮带（右+）
        /// </summary>
        public static int LensMoveX5 = 2;

        /// <summary>
        /// 6号皮带（右+）
        /// </summary>
        public static int LensMoveX6 = 3;

        /// <summary>
        /// 焦度计镜头Z向升起（上+）
        /// </summary>
        public static int NidekMoveZ = 4;

        /// <summary>
        /// 上厚度接触头（下+）
        /// </summary>
        public static int ContactMoveZ1 = 5;

        /// <summary>
        /// 下厚度接触头（上+）
        /// </summary>
        public static int ContactMoveZ2 = 6;

        /// <summary>
        /// 焦度计镜头Z向升起（上+）
        /// </summary>
        public static int PrinterMoveZ = 7;

        /// <summary>
        /// 卡2轴数
        /// </summary>
        public static int GTS800Total = 8;
    }
}
