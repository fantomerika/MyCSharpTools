using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinServerManage.Engine.Input;
using WinServerManage.Engine.Interface;

namespace WinServerManage.Engine.Core
{
    /// <summary>
    /// 通用游戏类
    /// </summary>
    public abstract class CGame : ICGame
    {
        #region 字段
        /// <summary>
        /// 控制台句柄
        /// </summary>
        private IntPtr m_hwnd = IntPtr.Zero;
        /// <summary>
        /// 鼠标输入设备
        /// </summary>
        //private CMouse m_dc_mouse;
        /// <summary>
        /// 键盘输入设备
        /// </summary>
        private CKeyboard m_dc_keyboard;
        /// <summary>
        /// 画面更新速率
        /// </summary>
        private Int32 m_updateRate;
        /// <summary>
        /// 当前帧数
        /// </summary>
        private Int32 m_fps;
        /// <summary>
        /// 记录帧数
        /// </summary>
        private Int32 m_tickCount;
        /// <summary>
        /// 记录上次运行时间
        /// </summary>
        private Int32 m_lastTime;
        /// <summary>
        /// 游戏是否结束
        /// </summary>
        private Boolean m_isGameOver;
        #endregion

        #region 构造函数
        public CGame()
        {
            m_hwnd = FindWindow(null, getTitle());
            //m_dc_mouse = new CMouse(m_hwnd);
            m_dc_keyboard = new CKeyboard();

            //订阅鼠标事件
            //m_dc_mouse.addMouseMoveEvent(gameMouseMove);
            //m_dc_mouse.addMouseAwayEvent(gameMouseAway);
            //m_dc_mouse.addMouseDownEvent(gameMouseDown);

            //订阅键盘事件
            m_dc_keyboard.addKeyDownEvent(gameKeyDown);
            m_dc_keyboard.addKeyUpEvent(gameKeyUp);

            m_isGameOver = false;
        }

        #endregion

        #region 游戏运行函数

        /// <summary>
        /// 游戏初始化
        /// </summary>
        protected abstract void gameInit();
        /// <summary>
        /// 游戏逻辑
        /// </summary>
        protected abstract void gameLoop();
        /// <summary>
        /// 游戏结束
        /// </summary>
        protected abstract void gameExit();

        /// <summary>
        /// 游戏输入
        /// </summary>
        private void gameInput()
        {
            //处理鼠标事件
            //this.getMouseDevice().mouseEventsHandler();
            //处理键盘事件
            this.getKeyboardDevice().keyboardEventsHandler();
        }
        #endregion

        #region 游戏设置函数
        /// <summary>
        /// 设置画面更新速率
        /// </summary>
        /// <param name="rate"></param>
        protected void setUpdateRate(Int32 rate)
        {
            this.m_updateRate = rate;
        }
        /// <summary>
        /// 获取画面更新速率
        /// </summary>
        /// <param name="rate"></param>
        protected Int32 getUpdateRate()
        {
            return this.m_updateRate;
        }
        /// <summary>
        /// 获取FPS
        /// </summary>
        /// <param name="rate"></param>
        protected Int32 getFPS()
        {
            return this.m_updateRate;
        }
        /// <summary>
        /// 计算FPS
        /// </summary>
        protected void setFPS()
        {
            Int32 ticks = Environment.TickCount;
            m_tickCount += 1;
            if (ticks - m_lastTime >= 1000)
            {
                m_fps = m_tickCount;
                m_tickCount = 0;
                m_lastTime = ticks;
            }
        }

        /// <summary>
        /// 延迟
        /// </summary>
        protected void delay()
        {
            this.delay(1);
        }

        protected void delay(Int32 time)
        {
            Thread.Sleep(time);
        }

        /// <summary>
        /// 游戏结束
        /// </summary>
        protected void setGameOver()
        {
            this.m_isGameOver = true;
        }
        /// <summary>
        /// 游戏是否结束
        /// </summary>
        protected Boolean isGameOver()
        {
            return this.m_isGameOver;
        }
        /// <summary>
        /// 设置光标是否可见
        /// </summary>
        protected void setCursorVisible(Boolean visible)
        {
            Console.CursorVisible = visible;
        }
        /// <summary>
        /// 设置控制台标题
        /// </summary>
        protected void setTitle(string Title)
        {
            Console.Title = Title;
        }
        /// <summary>
        /// 获取控制台标题
        /// </summary>
        protected string getTitle()
        {
            return Console.Title;
        }

        /// <summary>
        /// 关闭程序释放资源
        /// </summary>
        private void close()
        {
            Environment.Exit(0);
        }

        #endregion

        #region 游戏启动接口
        public void run()
        {
            this.gameInit();
            Int32 startTime = 0;
            while (!this.isGameOver())
            {
                //启动及计时
                startTime = Environment.TickCount;
                //计算 FPS
                this.setFPS();
                //游戏输入
                gameInput();
                //游戏逻辑
                this.gameLoop();
                //保持一定的FPS
                while (Environment.TickCount - startTime < this.m_updateRate)
                {
                    this.delay();
                }
            }
            this.gameExit();
            this.close();
        }
        #endregion

        #region API函数
        [DllImport("User32.dll")]
        private static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        #endregion

        #region 游戏输入设备
        /// <summary>
        /// 获取鼠标输入设备
        /// </summary>
        /// <returns></returns>
        //internal CMouse getMouseDevice()
        //{
        //    return m_dc_mouse;
        //}

        /// <summary>
        /// 获取键盘输入设备
        /// </summary>
        /// <returns></returns>
        internal CKeyboard getKeyboardDevice()
        {
            return m_dc_keyboard;
        }
        #endregion

        #region 游戏输入事件
        //protected virtual void gameMouseMove(CMouseEventArgs e)
        //{
        //    //此处处理鼠标移动事件
        //}

        /// <summary>
        /// 鼠标离开虚拟函数
        /// </summary>
        /// <param name="e"></param>
        //protected virtual void gameMouseAway(CMouseEventArgs e)
        //{
        //    //此处处理鼠标离开事件
        //}


        /// <summary>
        /// 鼠标按下虚拟函数
        /// </summary>
        /// <param name="e"></param>
        //protected virtual void gameMouseDown(CMouseEventArgs e)
        //{
        //    //此处处理鼠标按下事件
        //}

        /// <summary>
        /// 键盘按下虚拟函数
        /// </summary>
        /// <param name="e"></param>
        protected virtual void gameKeyDown(CKeyboardEventArgs e)
        {
            //此处处理键盘按下事件
        }

        /// <summary>
        /// 键盘释放虚拟函数
        /// </summary>
        /// <param name="e"></param>
        protected virtual void gameKeyUp(CKeyboardEventArgs e)
        {
            //此处处理键盘释放事件
        }
        #endregion
    }
}
