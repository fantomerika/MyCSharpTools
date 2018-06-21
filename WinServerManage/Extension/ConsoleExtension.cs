using System;

namespace WinServerManage.Extension
{
    public static class ConsoleExtension
    {
        #region 控制台输出
        public static void Print(this string str, ConsoleColor FontColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = FontColor;
            Console.Write(str);
        }
        public static void PrintLine(this string str,ConsoleColor FontColor=ConsoleColor.Green)
        {
            Console.ForegroundColor = FontColor;
            Console.WriteLine(str);
        }
        #endregion

    }
}
