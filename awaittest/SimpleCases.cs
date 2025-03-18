using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace awaittest
{
    public class SimpleCases
    {

        public void Run() {
            StartTheFileAnalyze();
            //UseCountOcc();
        }

        public void StartTheFileAnalyze() {
            Console.WriteLine("Start simple case");
            AnalyzeFile();
            Console.WriteLine("Started");
        }

        private async void AnalyzeFile()
        {
            Console.WriteLine("We are done with...");
            string[] fileContent = await File.ReadAllLinesAsync("jeopardy.json");
            Console.WriteLine("Reading data");
            // do all the analyzing stuff
            Thread.Sleep(1000);
            Console.WriteLine("Analyzing data");
        }


        private void UseCountOcc() {
            string word = "the";
            Task<int> taskHoldingTheResult = CountOcc(word);
            // den næste linie er blokerende
            int result = taskHoldingTheResult.Result;

            Console.WriteLine($"Ordet {word} forekommer {result} gange");
        }

        private async Task<int> CountOcc(string word)
        {
            string[] fileContent = await File.ReadAllLinesAsync("jeopardy.json");

            Console.WriteLine($"We are done with reading the file with {fileContent.Length} lines");
            int result = 0;

            // do the counting in the file
            result = CountOcc(fileContent, word);
            //Thread.Sleep(1000);
            Console.WriteLine("We are done with counting");

            return result;
        }        

        private int CountOcc(string[] a, string key) {
            int res = 0;
            Regex regex = new Regex(key);
            foreach (string line in a) {  
                MatchCollection matches = regex.Matches(line);
                res += matches.Count;
            }
            return res;
        }


        private Task<int> CountOccAsync(string[] a, string key)
        {
            Task<int> t = new Task<int>(() => { return CountOcc(a, key); });
            t.Start();
            return t;
        }
    }
}

