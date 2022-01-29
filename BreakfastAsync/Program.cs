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

            // If we want to change the execution order to, for example:
            // FryEggs first, then
            // CookBacon and ToastBread at the same time,
            // we'll need to:
            // FIRST: give a return type to FryEggs() of Task<bool>
            // SECOND: create a var for holding the result of FryEggs, call and await it from another sync method

            AnotherAsyncMethod(); // we use this as an "inbetween" because main isn't async


            Console.ReadLine(); // this is just to keep console from closing
        }

        public static async void AnotherAsyncMethod()
        {
            // this method will execute 1st
            var resultOfFryEggs = await FryEggs();

            //these 2 methods will execute 2d
            CookBacon();
            ToastBread();
        }


        // added a return type
        private static async Task<bool> FryEggs()
        {
            bool result = false;
            await Task.Run(() =>
            {
                Thread.Sleep(2000); // 2 secs
                Console.WriteLine("Eggs fried.");
                result = true;  
            });
            return result;
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