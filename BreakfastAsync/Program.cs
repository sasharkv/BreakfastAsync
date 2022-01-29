//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading;
using System.Threading.Tasks;

namespace BreakfastAsync // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // these 3 methods will be executed simultaneously
            FryEggs();
            CookBacon();
            ToastBread();
            Console.ReadLine(); // this is just to keep console from closing
        }

        private static async void FryEggs()
        {
            // put the method calls that you need inside an anonymous function that you pass in the Run() method of Task
            await Task.Run(() =>
            {
                Thread.Sleep(2000); // 2 secs
                Console.WriteLine("Eggs fried.");
            });
        }

        private static async void CookBacon()
        {
            await Task.Run(() =>
            {

                Thread.Sleep(2000);
                Console.WriteLine("Bacon cooked.");
            });
        }

        private static async void ToastBread()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Bread toasted.");
            });
        }

  
    }
}