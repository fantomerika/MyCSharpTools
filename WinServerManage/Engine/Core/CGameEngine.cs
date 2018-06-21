using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServerManage.Engine.Interface;
using WinServerManage.Extension;

namespace WinServerManage.Engine.Core
{
    /// <summary>
    /// 游戏启动类
    /// </summary>
    public class CGameEngine
    {
        public static void run(ICGame game)
        {
            if (game == null)
            {
                "引擎未初始化".PrintLine();
                Console.ReadLine();
            }
            else
            {
                game.run();
            }
        }
    }
}
