using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinServerManage.Engine.Input
{
    public sealed class CKeyboardEventArgs : EventArgs
    {
        private CKeys m_keys;

        public CKeyboardEventArgs(CKeys keys)
        {
            this.m_keys = keys;
        }

        public CKeys getKey()
        {
            return m_keys;
        }
    }
}
