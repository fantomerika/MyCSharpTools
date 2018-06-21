using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinServerManage.Model
{
    public class Menu
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 上级菜单
        /// </summary>
        public int PId { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string  FuncName { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<Menu> subMenu { get; set; }
        /// <summary>
        /// 操作序号
        /// </summary>
        public int Sort { get; set; }
    }
}
