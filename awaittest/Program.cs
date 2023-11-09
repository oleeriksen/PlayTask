namespace awaittest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new SimpleCases().Run();

            //new AwaitTest1();

            //run();
            Console.WriteLine("Hit any key to close...");
            Console.ReadKey();

        }

        static Task GetTask(int amount, string text){
            return new Task(() => write(amount, text));
        }

        static void write(int amount, string text){
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("" + (i + 1) + " " + text);
                Thread.Sleep(500);
            }
        }

        static async void run()
        {
            Console.WriteLine("Hello, Async World!");
            var t = GetTask(10, "peter");
            t.Start();
            Thread.Sleep(1000);
            await t;
            Console.WriteLine("After await");
        }


    }
}

