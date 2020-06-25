using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeCakeAsync
{
    public class AsyncCake
    {
        public async Task MakeCakeAsync()
        {
            Task<bool> preheatTask = PreheatOvenAsync(); // start/store this task (no blocking needed!) and come back to it later
            AddCakeIngredients();                        // make cake batter while waiting for the oven to preheat
            bool isPreheated = await preheatTask;        // get the result of preheat method in order to bake the cake

            Task<bool> bakeCakeTask = BakeCakeAsync(isPreheated); // start baking the cake and do other things while baking
            AddFrostingIngredients();                             // make the frosting while the cake is baking
            Task<bool> coolFrostingTask = CoolFrostingAsync();    // start cooling the frosting and come back to it when needed
            PassTheTime();                                        // do other things while cake is baking and frosting is cooling
            bool isBaked = await bakeCakeTask;                    // get the result of BakeCakeAsync() in order to cool the cake

            Task<bool> coolCakeTask = CoolCakeAsync(isBaked);     // start cooling the cake after it's done baking

            bool cakeIsCooled = await coolCakeTask;               // get the result of CoolCakeAsync() when finished
            bool frostingIsCooled = await coolFrostingTask;       // get the result of CoolFrostingAsync() when finished

            FrostCake(cakeIsCooled, frostingIsCooled);            // frost the cake once the cake and frosting are cooled

            Common.WriteToConsole("Cake is served! Bon Appetit!");    // Enjoy!
        }

        private async Task<bool> PreheatOvenAsync()
        {
            Common.WriteToConsole("Preheating oven...");
            await Task.Delay(2500);
            Common.WriteToConsole("Oven is ready!");
            return true;
        }

        private void AddCakeIngredients()
        {
            Thread.Sleep(500);
            Common.WriteToConsole("Added cake mix");
            Thread.Sleep(500);
            Common.WriteToConsole("Added milk");
            Thread.Sleep(500);
            Common.WriteToConsole("Added vegetable oil");
            Thread.Sleep(500);
            Common.WriteToConsole("Added eggs");

            Common.WriteToConsole("Cake ingredients mixed!");
        }

        private async Task<bool> BakeCakeAsync(bool isPreheated)
        {
            if (isPreheated)
            {
                Common.WriteToConsole("Baking cake...");
                await Task.Delay(5000);
                Common.WriteToConsole("Cake is done baking!");
                return true;
            }
            return false;
        }

        private void AddFrostingIngredients()
        {
            Thread.Sleep(500);
            Common.WriteToConsole("Added cream cheese");
            Thread.Sleep(500);
            Common.WriteToConsole("Added milk");
            Thread.Sleep(500);
            Common.WriteToConsole("Added vegetable oil");
            Thread.Sleep(500);
            Common.WriteToConsole("Added eggs");

            Common.WriteToConsole("Frosting ingredients mixed!");
        }

        private async Task<bool> CoolFrostingAsync()
        {
            Common.WriteToConsole("Cooling frosting...");
            await Task.Delay(2500);
            Common.WriteToConsole("Frosting is cooled!");
            return true;
        }

        private async Task<bool> CoolCakeAsync(bool isBaked)
        {
            if (isBaked)
            {
                Common.WriteToConsole("Cooling cake...");
                await Task.Delay(2500);
                Common.WriteToConsole("Cake is cooled!");
                return true;
            }
            return false;
        }

        private void FrostCake(bool cakeIsCooled, bool frostingIsCooled)
        {
            if (cakeIsCooled && frostingIsCooled)
            {
                Common.WriteToConsole("Frosting cake...");
                Thread.Sleep(1000);
                Common.WriteToConsole("Cake is frosted!");
            }
        }

        private void PassTheTime()
        {
            Thread.Sleep(500);
            Common.WriteToConsole("Watched TV");
            Thread.Sleep(500);
            Common.WriteToConsole("Ate lunch");
            Thread.Sleep(500);
            Common.WriteToConsole("Cleaned the kitchen");
        }
    }
}
