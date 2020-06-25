using System;

namespace MakeCake.WinForms
{
    public class Common
    {
        public static string WriteToConsole(string message)
        {
            Console.WriteLine(message + " " + DateTime.Now.ToString("hh:mm:ss"));
            return message;
        }
    }
}