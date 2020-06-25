using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MakeCakeAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Cake cake = new Cake();
            //cake.MakeCake();

            AsyncCake asyncCake = new AsyncCake();
            await asyncCake.MakeCakeAsync();
        }
    }

  

  



}
