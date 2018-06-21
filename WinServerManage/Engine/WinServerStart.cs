using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServerManage.Engine.Core;
using WinServerManage.Engine.Input;
using WinServerManage.Extension;
using WinServerManage.Service;

namespace WinServerManage.Engine
{
    public class WinServerStart : CGame
    {
        private Boolean m_bkeydown = false;
        private Int32 m_ticks;
        private Int32 m_lastTime;

        protected override void gameExit()
        {
            //"游戏结束！".PrintLine();
            //Console.ReadLine();
        }

        /// <summary>
        /// 游戏初始化
        /// </summary>
        protected override void gameInit()
        {
            setTitle("系统服务管理");
            //设置游戏画面刷新率 每毫秒一次
            setUpdateRate(100);
            setCursorVisible(false);

            "初始化成功！".PrintLine();
            //m_lastTime = Environment.TickCount;
        }

        /// <summary>
        /// 逻辑
        /// </summary>
        protected override void gameLoop()
        {
            ShowMenu();//刷新菜单
        }

        protected override void gameKeyDown(CKeyboardEventArgs e)
        {

            if (!m_bkeydown)
            {
                //$"按下键：{e.getKey()}".PrintLine();
                switch (e.getKey())
                {
                    case CKeys.D:
                        UserInfo.LastInputKey = "~";
                        break;
                    case CKeys.D0:
                        UserInfo.LastInputKey = "0";
                        break;
                    case CKeys.D1:
                        UserInfo.LastInputKey = "1";
                        break;
                    case CKeys.D2:
                        UserInfo.LastInputKey = "2";
                        break;
                    case CKeys.D3:
                        UserInfo.LastInputKey = "3";
                        break;
                    case CKeys.D4:
                        UserInfo.LastInputKey = "4";
                        break;
                    case CKeys.D5:
                        UserInfo.LastInputKey = "5";
                        break;
                    case CKeys.D6:
                        UserInfo.LastInputKey = "6";
                        break;
                    case CKeys.D7:
                        UserInfo.LastInputKey = "7";
                        break;
                    case CKeys.D8:
                        UserInfo.LastInputKey = "8";
                        break;
                    case CKeys.D9:
                        UserInfo.LastInputKey = "9";
                        break;
                }
                ExcuteMenuItem();
                m_bkeydown = true;
            }
            if (e.getKey() == CKeys.Escape)
            {
                setGameOver();
            }
        }

        protected override void gameKeyUp(CKeyboardEventArgs e)
        {
            //$"释放键：{e.getKey()}".PrintLine();
            m_bkeydown = false;
        }

        #region 功能方法
        /// <summary>
        /// 展示当前菜单内容
        /// </summary>
        public void ShowMenu()
        {
            Console.Clear();
            var data = new UI.ManuData().GetManuData();
            data.Where(d => d.Id == UserInfo.CurrentMenu).FirstOrDefault().Title.PrintLine();
            foreach (var item in data.Where(d => d.PId == UserInfo.CurrentMenu))
            {
                item.Name.PrintLine();
            }
        }

        /// <summary>
        /// 选中菜单选项
        /// </summary>
        public void ExcuteMenuItem()
        {
            int sort = 0;
            if (int.TryParse(UserInfo.LastInputKey, out sort))
            {
                var data = new UI.ManuData().GetManuData();
                var currentItem = data.Where(d => d.PId == UserInfo.CurrentMenu && d.Sort == sort).FirstOrDefault();
                if (currentItem != null)
                {
                    ///执行具体方法调用
                    if (!string.IsNullOrWhiteSpace(currentItem.FuncName))
                    {
                        FuncControl control = new FuncControl();
                        control.GetType().GetMethod(currentItem.FuncName).Invoke(control, null);
                    }
                    ///判断是否有子菜单 有就显示为新菜单
                    if (data.Where(d => d.PId == currentItem.Id).Count() > 0) UserInfo.CurrentMenu = currentItem.Id;
                }
            }
        }
        #endregion
    }
}
