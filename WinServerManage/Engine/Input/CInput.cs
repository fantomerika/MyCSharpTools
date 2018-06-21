using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinServerManage.Engine.Input
{
    internal abstract class CInput
    {
        internal const Int32 KEY_STATE = 0x8000;
        /// <summary>
        /// 判断函数调用时指定虚拟键的状态
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        protected static extern Int16 GetAsyncKeyState(Int32 vKey);
        /// <summary>
        /// 获取光标位置
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        //[DllImport("User32.dll")]
        //protected static extern Boolean GetCursorPos(out CPoint lpPoint);
        /// <summary>
        /// 屏幕坐标转换成工作区坐标
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
//        [DllImport("User32.dll")]
//        protected static extern Int16 ScreenToClient(IntPtr hwnd, out CPoint
//lpPoint);
    }
}
