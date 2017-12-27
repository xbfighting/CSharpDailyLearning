using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnumOperator
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <remarks>没有定义 Description ，将直接返回枚举名称</remarks>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            DescriptionAttribute da = (DescriptionAttribute)objs[0];
            return da.Description;
        }
    }
}

namespace System

{
    public static class EnumExt
    {
        public static string GetDescription(this Enum sourceEnum)
        {
            object enumValue = sourceEnum;
            Type enumType = sourceEnum.GetType();
            return enumType.GetEnumDescription(enumValue);
        }

        public static string GetEnumDescription(this Type enumType, object enumValue)
        {
            try
            {
                FieldInfo fi = enumType.GetField(Enum.GetName(enumType, enumValue));
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : Enum.GetName(enumType, enumValue);
            }
            catch (Exception e)
            {
                return "UNKNOWN";
            }
        }

    }
}