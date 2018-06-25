using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServerManage.Extension;

namespace WinServerManage.Service
{
    public class FuncControl
    {
        /// <summary>
        /// 退出系统
        /// </summary>
        public void Eixt()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 安装Windows服务：
        /// </summary>
        public void InstallService()
        {
            "请输入要安装的Windows服务文件所在路径：".PrintLine();
            var servicePath = Console.ReadLine();
            try
            {
                new WinServiceControl().InstallService(servicePath);
                "完成。".PrintLine(ConsoleColor.Blue);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ex.Message.PrintLine(ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void UnInstallService()
        {
            "请输入要删除的Windows服务文件所在路径：".PrintLine();
            var servicePath = Console.ReadLine();
            try
            {
                new WinServiceControl().UninstallService(servicePath);
                "完成。".PrintLine(ConsoleColor.Blue);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ex.Message.PrintLine(ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void ServiceStart()
        {
            "请输入要启动的Windows服务名称：".PrintLine();
            var serviceName = Console.ReadLine();
            try
            {
                new WinServiceControl().ServiceStart(serviceName);
                "完成。".PrintLine(ConsoleColor.Blue);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ex.Message.PrintLine(ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void ServiceEnd()
        {
            "请输入要结束的Windows服务名称：".PrintLine();
            var serviceName = Console.ReadLine();
            try
            {
                new WinServiceControl().ServiceStop(serviceName);
                "完成。".PrintLine(ConsoleColor.Blue);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ex.Message.PrintLine(ConsoleColor.Red);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void doTest()
        {
            new JobScheduling.test().start();
        }
    }
}
