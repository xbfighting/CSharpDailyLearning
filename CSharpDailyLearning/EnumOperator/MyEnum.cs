using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumOperator
{

    public class EnumOperator
    {
        public static string GetEnumDescriptionByInt(int? number)
        {
            return ((PackageStoredTypeEnum) number).GetDescription();
        }
    }

    /// <summary>
    /// 包裹温层枚举
    /// </summary>
    public enum PackageStoredTypeEnum
    {
        /// <summary>
        /// UnKnown
        /// </summary>
        [Description("UNKNOWN")]
        UnKnown = 0,
        [Description("常温")]
        Normal = 1,
        [Description("冷冻")]
        Freeze = 2,
        [Description("冷藏")]
        ColdStorage = 4,
        [Description("活鲜")]
        Fresh = 8,
    }
}
