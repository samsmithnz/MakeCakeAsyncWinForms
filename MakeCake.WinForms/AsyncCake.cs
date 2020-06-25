using System.Threading.Tasks;

namespace MakeCake.WinForms
{
    public class AsyncCake
    {
        public string CurrentStatus { get; set; }
        private Task<bool> preheatTask;
        private bool isPreheated;
        private Task<bool> bakeCakeTask;
        private bool isBaked;

        public async Task MakeCakeAsync(int task)
        {
            //CurrentStatus = "task " + task;
            switch (task)
            {
                case int n when (n >= 1 && n <= 2):
                    preheatTask = PreheatOvenAsync(task);
                    isPreheated = await preheatTask;
                    break;
                case int n when (n >= 3 && n <= 7):
                    await AddCakeIngredients(task);
                    break;
                case int n when (n >= 8 && n <= 9):
                    bakeCakeTask = BakeCakeAsync(task, isPreheated);
                    isBaked = await bakeCakeTask;   
                    break;
            }

            //Task<bool> preheatTask = PreheatOvenAsync(); // start/store this task (no blocking needed!) and come back to it later
            //AddCakeIngredients();                        // make cake batter while waiting for the oven to preheat
            //bool isPreheated = await preheatTask;        // get the result of preheat method in order to bake the cake

            //Task<bool> bakeCakeTask = BakeCakeAsync(isPreheated); // start baking the cake and do other things while baking
            //AddFrostingIngredients();                             // make the frosting while the cake is baking
            //Task<bool> coolFrostingTask = CoolFrostingAsync();    // start cooling the frosting and come back to it when needed
            //PassTheTime();                                        // do other things while cake is baking and frosting is cooling
            //bool isBaked = await bakeCakeTask;                    // get the result of BakeCakeAsync() in order to cool the cake

            //Task<bool> coolCakeTask = CoolCakeAsync(isBaked);     // start cooling the cake after it's done baking

            //bool cakeIsCooled = await coolCakeTask;               // get the result of CoolCakeAsync() when finished
            //bool frostingIsCooled = await coolFrostingTask;       // get the result of CoolFrostingAsync() when finished

            //FrostCake(cakeIsCooled, frostingIsCooled);            // frost the cake once the cake and frosting are cooled

            //Common.WriteToConsole("Cake is served! Bon Appetit!");    // Enjoy!
        }

        private async Task<bool> PreheatOvenAsync(int task)
        {
            if (task == 1)
            {
                CurrentStatus = ("Preheating oven...");
                await Task.Delay(1000);
            }
            else if (task == 2)
            {
                CurrentStatus = ("Oven is ready!");
                await Task.Delay(1000);
            }
            else
            {
                CurrentStatus = "lost in PreheatOven";
            }
            return true;
        }

        private async Task AddCakeIngredients(int task)
        {
            if (task == 3)
            {
                CurrentStatus = ("Added cake mix");
                await Task.Delay(1000);
            }
            else if (task == 4)
            {
                CurrentStatus = ("Added milk");
                await Task.Delay(1000);
            }
            else if (task == 5)
            {
                CurrentStatus = ("Added vegetable oil");
                await Task.Delay(1000);
            }
            else if (task == 6)
            {
                CurrentStatus = ("Added eggs");
                await Task.Delay(1000);
            }
            else if (task == 7)
            {
                CurrentStatus = ("Cake ingredients mixed!");
                await Task.Delay(1000);
            }
            else
            {
                CurrentStatus = "lost in AddCakeIngredients";
            }
        }

        private async Task<bool> BakeCakeAsync(int task, bool isPreheated)
        {
            if (isPreheated)
            {
                if (task == 8)
                {
                    CurrentStatus = ("Baking cake...");
                    await Task.Delay(1000);
                }
                else if (task == 9)
                {
                    CurrentStatus = ("Cake is done baking!");
                    await Task.Delay(1000);
                }
                else
                {
                    CurrentStatus = "lost in BakeCake";
                }
                return true;
            }
            return false;
        }

        private async Task AddFrostingIngredients()
        {
            await Task.Delay(1000);
            Common.WriteToConsole("Added cream cheese");
            await Task.Delay(1000);
            Common.WriteToConsole("Added milk");
            await Task.Delay(1000);
            Common.WriteToConsole("Added vegetable oil");
            await Task.Delay(1000);
            Common.WriteToConsole("Added eggs");

            Common.WriteToConsole("Frosting ingredients mixed!");
        }

        private async Task<bool> CoolFrostingAsync()
        {
            Common.WriteToConsole("Cooling frosting...");
            await Task.Delay(1000);
            Common.WriteToConsole("Frosting is cooled!");
            return true;
        }

        private async Task<bool> CoolCakeAsync(bool isBaked)
        {
            if (isBaked)
            {
                Common.WriteToConsole("Cooling cake...");
                await Task.Delay(1000);
                Common.WriteToConsole("Cake is cooled!");
                return true;
            }
            return false;
        }

        private async Task FrostCake(bool cakeIsCooled, bool frostingIsCooled)
        {
            if (cakeIsCooled && frostingIsCooled)
            {
                Common.WriteToConsole("Frosting cake...");
                await Task.Delay(1000);
                Common.WriteToConsole("Cake is frosted!");
            }
        }

        private async Task PassTheTime()
        {
            await Task.Delay(1000);
            Common.WriteToConsole("Watched TV");
            await Task.Delay(1000);
            Common.WriteToConsole("Ate lunch");
            await Task.Delay(1000);
            Common.WriteToConsole("Cleaned the kitchen");
        }
    }
}
