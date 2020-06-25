using System;
using System.Collections.Generic;
using System.Text;

namespace MakeCakeAsync
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
