using System.Diagnostics;

namespace Scrapper
{

    public class AsyncBreakfast
    {
        public async Task MakeBreakfast()
        {
            var watch = Stopwatch.StartNew();
            MakeCoffee();

            FryEggs();

            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
            ServeBreakfast();
        }

        public async Task MakeBreakfastAsync()
        {
            var watch = Stopwatch.StartNew();
            
            Task coffeeTask = MakeCoffeeAsync();

            Task eggsTask = FryEggsAsync();

            await Task.WhenAll(coffeeTask, eggsTask);

            watch.Stop();
            Console.WriteLine(watch.Elapsed.ToString());
            ServeBreakfast();

        }

        public async Task MakeCoffeeAsync()
        {
            Console.WriteLine("Making coffee...");
            // Simulating time-consuming coffee-making process
            await Task.Delay(2000);
            Console.WriteLine("Coffee is ready!");
        }

        public async Task FryEggsAsync()
        {
            Console.WriteLine("Frying eggs...");
            // Simulating time-consuming egg frying process
            await Task.Delay(3000);
            Console.WriteLine("Eggs are ready!");
        }

        public void MakeCoffee()
        {
            Console.WriteLine("Making coffee...");
            // Simulating time-consuming coffee-making process
            Thread.Sleep(2000);
            Console.WriteLine("Coffee is ready!");
        }

        public void FryEggs()
        {
            Console.WriteLine("Frying eggs...");
            // Simulating time-consuming egg frying process
            Thread.Sleep(3000);
            Console.WriteLine("Eggs are ready!");
        }

        public void ServeBreakfast()
        {
            Console.WriteLine("Serving breakfast...");
            Console.WriteLine("Enjoy your breakfast!");
        }
    //internal class Bacon { }
    //internal class Coffee { }
    //internal class Egg { }
    //internal class Juice { }
    //internal class Toast { }

    //public class AsyncBreakfast
    //{
    //    public async Task MakeBreakfast()
    //    {
    //        var watch = Stopwatch.StartNew();
    //        Coffee cup = PourCoffee();
    //        Console.WriteLine("coffee is ready");

    //        var eggsTask = FryEggsAsync(2);
    //        var baconTask = FryBaconAsync(3);
    //        var toastTask = MakeToastWithButterAndJamAsync(2);

    //        var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
    //        while (breakfastTasks.Count > 0)
    //        {
    //            Task finishedTask = await Task.WhenAny(breakfastTasks);
    //            if (finishedTask == eggsTask)
    //            {
    //                Console.WriteLine("eggs are ready");
    //            }
    //            else if (finishedTask == baconTask)
    //            {
    //                Console.WriteLine("bacon is ready");
    //            }
    //            else if (finishedTask == toastTask)
    //            {
    //                Console.WriteLine("toast is ready");
    //            }
    //            await finishedTask;
    //            breakfastTasks.Remove(finishedTask);
    //        }

    //        Juice oj = PourOJ();
    //        Console.WriteLine("oj is ready");
    //        Console.WriteLine("Breakfast is ready!");
    //        watch.Stop();
    //        Console.WriteLine($"Elapsed time: {watch.Elapsed}");
    //    }

    //    static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    //    {
    //        var toast = await ToastBreadAsync(number);
    //        ApplyButter(toast);
    //        ApplyJam(toast);

    //        return toast;
    //    }

    //    private static Juice PourOJ()
    //    {
    //        Console.WriteLine("Pouring orange juice");
    //        return new Juice();
    //    }

    //    private static void ApplyJam(Toast toast) =>
    //        Console.WriteLine("Putting jam on the toast");

    //    private static void ApplyButter(Toast toast) =>
    //        Console.WriteLine("Putting butter on the toast");

    //    private static async Task<Toast> ToastBreadAsync(int slices)
    //    {
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("Putting a slice of bread in the toaster");
    //        }
    //        Console.WriteLine("Start toasting...");
    //        await Task.Delay(3000);
    //        Console.WriteLine("Remove toast from toaster");

    //        return new Toast();
    //    }

    //    private static async Task<Bacon> FryBaconAsync(int slices)
    //    {
    //        Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //        Console.WriteLine("cooking first side of bacon...");
    //        await Task.Delay(3000);
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("flipping a slice of bacon");
    //        }
    //        Console.WriteLine("cooking the second side of bacon...");
    //        await Task.Delay(3000);
    //        Console.WriteLine("Put bacon on plate");

    //        return new Bacon();
    //    }

    //    private static async Task<Egg> FryEggsAsync(int howMany)
    //    {
    //        Console.WriteLine("Warming the egg pan...");
    //        await Task.Delay(3000);
    //        Console.WriteLine($"cracking {howMany} eggs");
    //        Console.WriteLine("cooking the eggs ...");
    //        await Task.Delay(3000);
    //        Console.WriteLine("Put eggs on plate");

    //        return new Egg();
    //    }

    //    private static Coffee PourCoffee()
    //    {
    //        Console.WriteLine("Pouring coffee");
    //        return new Coffee();
    //    }
}
}
