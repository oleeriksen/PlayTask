using System;
namespace awaittest
{
	public class AwaitTest1
	{
        public AwaitTest1()
        {
            Console.WriteLine("A");
            Execute();
            Console.WriteLine("B");
        }

        public async void Execute()
        {
            
            Console.WriteLine("C");

            await f1();

            Console.WriteLine("D");

        }

        private async Task f1()
        {
            Console.WriteLine("E");
            int res = await CountSomething();
            Console.WriteLine($"F");

        }

        private Task<int> CountSomething()
        {
            Task<int> t = new Task<int>(() => {
                Thread.Sleep(3000);
                return 1234;
            });
            t.Start();
            return t;
        }
    }
}

