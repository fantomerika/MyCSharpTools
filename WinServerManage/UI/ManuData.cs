using System;
using System.Collections.Generic;
using WinServerManage.Model;

namespace WinServerManage.UI
{
    /// <summary>
    /// 菜单类
    /// </summary>
    public class ManuData
    {
        public List<Menu> GetManuData()
        {
            var listData = new List<Menu>();
            listData.Add(new Menu()
            {
                Id = 0,
                Name = "",
                Title = "================windows服务管理===================="
            });
            listData.Add(new Menu()
            {
                Id = 1,
                Name = "1.windows服务安装",
                FuncName = "InstallService",
                PId = 0,
                Sort = 1
            });
            listData.Add(new Menu()
            {
                Id = 2,
                Name = "2.windows服务卸载",
                FuncName = "Eixt",
                PId = 0,
                Sort = 1
            });
            listData.Add(new Menu()
            {
                Id = 3,
                Name = "3.windows服务开启",
                FuncName = "Eixt",
                PId = 0,
                Sort = 1
            });
            listData.Add(new Menu()
            {
                Id = 4,
                Name = "4.windows服务停止",
                FuncName = "Eixt",
                PId = 0,
                Sort = 4
            });
            listData.Add(new Menu()
            {
                Id = 5,
                Name = "5.退出",
                FuncName = "Eixt",
                PId=0,
                Sort=5
            });
            listData.Add(new Menu()
            {
                Id = 6,
                Name = "6.调用测试方法",
                FuncName = "doTest",
                PId = 0,
                Sort = 6
            });
            return listData;
        }
    }
}
