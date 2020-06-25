using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeCakeAsync
{
    public class SyncCake
    {
        public string CurrentStatus { get; set; }

        public void MakeCake(int task)
        {
            CurrentStatus = "task " + task;
            switch (task)
            {
                case int n when (n >= 1 && n <= 2):
                    PreheatOven(task);
                    break;
                case int n when (n >= 3 && n <= 7):
                    AddCakeIngredients(task);
                    break;
                case int n when (n >= 8 && n <= 9):
                    BakeCake(task);
                    break;
                case int n when (n >= 10 && n <= 14):
                    AddFrostingIngredients(task);
                    break;
                case int n when (n >= 15 && n <= 16):
                    CoolFrosting(task);
                    break;
                case int n when (n >= 17 && n <= 18):
                    CoolCake(task);
                    break;
                case 19:
                    FrostCake(task);
                    break;
                case 20:
                    WrapupCake(task);
                    break;
            }
        }

        private void PreheatOven(int task)
        {
            if (task == 1)
            {
                CurrentStatus = ("Preheating oven...");
                Thread.Sleep(2500);
            }
            else if (task == 2)
            {
                CurrentStatus = ("Oven is ready!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in PreheatOven";
            }
        }

        private void AddCakeIngredients(int task)
        {
            if (task == 3)
            {
                CurrentStatus = ("Added cake mix");
                Thread.Sleep(500);
            }
            else if (task == 4)
            {
                CurrentStatus = ("Added milk");
                Thread.Sleep(500);
            }
            else if (task == 5)
            {
                CurrentStatus = ("Added vegetable oil");
                Thread.Sleep(500);
            }
            else if (task == 6)
            {
                CurrentStatus = ("Added eggs");
                Thread.Sleep(500);
            }
            else if (task == 7)
            {
                CurrentStatus = ("Cake ingredients mixed!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in AddCakeIngredients";
            }
        }

        private void BakeCake(int task)
        {
            if (task == 8)
            {
                CurrentStatus = ("Baking cake...");
                Thread.Sleep(5000);
            }
            else if (task == 9)
            {
                CurrentStatus = ("Cake is done baking!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in BakeCake";
            }
        }

        private void AddFrostingIngredients(int task)
        {
            if (task == 10)
            {
                CurrentStatus = ("Added cream cheese");
                Thread.Sleep(500);
            }
            else if (task == 11)
            {
                CurrentStatus = ("Added milk");
                Thread.Sleep(500);
            }
            else if (task == 12)
            {
                CurrentStatus = ("Added vegetable oil");
                Thread.Sleep(500);
            }
            else if (task == 13)
            {
                CurrentStatus = ("Added eggs");
                Thread.Sleep(500);
            }
            else if (task == 14)
            {
                CurrentStatus = ("Frosting ingredients mixed!");
                Thread.Sleep(500);
            }
            else
            {
                CurrentStatus = "lost in AddFrostingIngredients";
            }
        }

        private void CoolFrosting(int task)
        {
            if (task == 15)
            {
                CurrentStatus = ("Cooling frosting...");
                Thread.Sleep(2500);
            }
            else if (task == 16)
            {
                CurrentStatus = ("Frosting is cooled!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in CoolFrosting";
            }
        }

        private void CoolCake(int task)
        {
            if (task == 17)
            {
                CurrentStatus = ("Cooling cake...");
                Thread.Sleep(2500);
            }
            else if (task == 18)
            {
                CurrentStatus = ("Cake is cooled!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in CoolCake";
            }
        }

        private void FrostCake(int task)
        {
            if (task == 19)
            {
                CurrentStatus = ("Cake is frosted!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in FrostCake";
            }
        }

        private void WrapupCake(int task)
        {
            if (task == 20)
            {
                CurrentStatus = ("Cake is served! Bon Appetit!");
                Thread.Sleep(250);
            }
            else
            {
                CurrentStatus = "lost in WrapupCake";
            }
        }
    }
}
