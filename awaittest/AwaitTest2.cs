using System;
namespace awaittest
{
	public class AwaitTest2
	{
		public AwaitTest2()
		{
            Console.WriteLine("Start Main");
            ExecuteMany(3);
            Console.WriteLine("End Main");
        }

        public async void ExecuteMany(int n) {
            var start = DateTime.Now;
            Console.WriteLine($"Execute {n} tasks");
            for (int x = 1; x <= n; x++)
                     await f1(x);

            var time = (DateTime.Now - start).TotalMilliseconds;
            Console.WriteLine($"End of {n} tasks - {time} used");

        }

        private async Task f1(int x) {
            Console.WriteLine($"Start Task {x}");
            int res = await CountSomething();
            Console.WriteLine($"End Task {x}");

        }

        private Task<int> CountSomething()
        {
            Task<int> t = new Task<int>(() => { Thread.Sleep(3000);
                return 1234; });
            t.Start();
            return t;
        }
    }
}

