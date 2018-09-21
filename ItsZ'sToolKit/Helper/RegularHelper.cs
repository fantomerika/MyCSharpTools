using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ItsZ_sToolKit.Helper
{
    public static class RegularHelper
    {
        /// <summary>
        /// 车牌号正则验证
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public static bool IsVehicleNumber(this string vehicleNumber)
        {   
            bool result = false;
            if (vehicleNumber.Length == 7)
            {
                string express = @"^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$";
                result = Regex.IsMatch(vehicleNumber, express);
            }
            return result;
        }

        /// <summary>
        /// 身份证
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public static bool IsIdCard(this string card)
        {
            string express = @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$";
            if (card.Length != 15) express = @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$";
            return Regex.IsMatch(card, express);
        }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static bool IsTelPhone(this string tel)
        {
            string express = @"0?(13|14|15|17|18|19)[0-9]{9}";
            return Regex.IsMatch(tel, express);
        }
    }
}
