using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServerManage.Engine.Input;

namespace WinServerManage
{
    public static class UserInfo
    {
        /// <summary>
        /// 当前所在菜单
        /// </summary>
        public static int CurrentMenu {
            get;
            set;
        }

        /// <summary>
        /// 上一个菜单
        /// </summary>
        public static int LastMenu { get; set; }

        /// <summary>
        /// 最后输入的值
        /// </summary>
        public static string LastInputKey { get; set; }
    }
}
