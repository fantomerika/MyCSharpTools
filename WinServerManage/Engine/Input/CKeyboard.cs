using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinServerManage.Engine.Input
{
    internal sealed class CKeyboard : CInput
    {
        /// <summary>
        /// 键盘事件委托
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="e"></param>
        internal delegate void CKeyboardHandler<TEventArgs>(TEventArgs e);

        /// <summary>
        /// 键盘按下事件委托
        /// </summary>
        private event CKeyboardHandler<CKeyboardEventArgs> m_keyDown;

        /// <summary>
        /// 键盘释放事件
        /// </summary>
        private event CKeyboardHandler<CKeyboardEventArgs> m_keyUp;

        /// <summary>
        /// 上次按下的键值
        /// </summary>
        private CKeys m_oldKey = CKeys.None;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CKeyboard()
        {
        }

        /// <summary>
        /// 是否按下键
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        private Boolean isKeyDown(CKeys vKey)
        {
            return 0 != (GetAsyncKeyState((Int32)vKey) & KEY_STATE);
        }

        /// <summary>
        /// 获取键盘按下的键值
        /// </summary>
        /// <returns></returns>
        private CKeys getCurKeyboardDownKey()
        {
            CKeys vKye = CKeys.None;
            foreach (Int32 key in Enum.GetValues(typeof(CKeys)))
            {
                if (isKeyDown((CKeys)key))
                {
                    vKye = (CKeys)key;
                    break;
                }
            }
            return vKye;
        }

        /// <summary>
        /// 响应键盘按下事件
        /// </summary>
        /// <param name="e"></param>
        private void onKeyDown(CKeyboardEventArgs e)
        {
            CKeyboardHandler<CKeyboardEventArgs> temp = m_keyDown;
            if (temp != null)
            {
                temp.Invoke(e);
            }
        }

        /// <summary>
        /// 响应键盘释放事件
        /// </summary>
        /// <param name="e"></param>
        private void onKeyUp(CKeyboardEventArgs e)
        {
            CKeyboardHandler<CKeyboardEventArgs> temp = m_keyUp;
            if (temp != null)
            {
                temp.Invoke(e);
            }
        }

        /// <summary>
        /// 添加键盘按下事件
        /// </summary>
        /// <param name="fu"></param>
        /// <param name=""></param>
        public void addKeyDownEvent(CKeyboardHandler<CKeyboardEventArgs> func)
        {
            m_keyDown += func;
        }

        /// <summary>
        /// 添加键盘释放事件
        /// </summary>
        /// <param name="func"></param>
        public void addKeyUpEvent(CKeyboardHandler<CKeyboardEventArgs> func)
        {
            this.m_keyUp += func;
        }

        /// <summary>
        /// 键盘事件处理
        /// </summary>
        public void keyboardEventsHandler()
        {
            CKeyboardEventArgs e;
            CKeys vKeyDown = getCurKeyboardDownKey();

            if (vKeyDown != CKeys.None)
            {
                this.m_oldKey = vKeyDown;
                e = new CKeyboardEventArgs(vKeyDown);
                this.onKeyDown(e);
            }
            else if (m_oldKey != CKeys.None && !isKeyDown(this.m_oldKey))
            {
                e = new CKeyboardEventArgs(this.m_oldKey);
                this.onKeyUp(e);
                this.m_oldKey = CKeys.None;
            }
        }
    }
}
