using System;
namespace awaittest
{
	public class TaskTest1
	{
		public async void Run() {
			Console.WriteLine("Start");
			Task t = new Task(() => Print10Lines('A'));
			t.Start();
			await t;

			Print10Lines('B');

		}

		private void Print10Lines(char id) {
			for (int i = 1; i <= 10; i++)
				Console.WriteLine($"{id}- {i}");
		}
	}
}

