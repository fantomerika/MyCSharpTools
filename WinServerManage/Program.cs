using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServerManage.Engine;
using WinServerManage.Engine.Core;

namespace WinServerManage
{
    class Program
    {
        static void Main(string[] args)
        {
            CGameEngine.run(new WinServerStart());
        }
    }
}
