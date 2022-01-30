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
           // var resultOfFryEggs = await FryEggs();

            // CookBacon (async) and Tester (sync) will start at the same time. They will finish at the same time because they bothe have 2 sec delay.
            // Then Tester2 (sync) will start.
            // But ToastBread(async) will have to wait for Tester2 (sync) to complete to be able to start.
            CookBacon();
            Tester();
            Tester2();
            ToastBread();
        }

        public static void Tester()
        {
            Console.WriteLine("Test start " + DateTime.Now.TimeOfDay);
            Thread.Sleep(2000);
            Console.WriteLine("Test end " + DateTime.Now.TimeOfDay);
        }

        public static void Tester2()
        {
            Console.WriteLine("Test2 start " + DateTime.Now.TimeOfDay);
            Thread.Sleep(2000);
            Console.WriteLine("Test2 end " + DateTime.Now.TimeOfDay);
        }


        // added a return type
        private static async Task<bool> FryEggs()
        {
            bool result = false;
            await Task.Run(() =>
            {
                Console.WriteLine("Eggs start" + DateTime.Now.TimeOfDay);
                Thread.Sleep(2000); // 2 secs
                Console.WriteLine("Eggs fried. " + DateTime.Now.TimeOfDay);
                result = true;  
            });
            return result;
        }

        private static async void CookBacon()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Bacon start" + DateTime.Now.TimeOfDay);
                Thread.Sleep(2000);
                Console.WriteLine("Bacon cooked. " + DateTime.Now.TimeOfDay);
            });
        }

        private static async void ToastBread()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Bread start" + DateTime.Now.TimeOfDay);
                Thread.Sleep(2000);
                Console.WriteLine("Bread toasted. " + DateTime.Now.TimeOfDay);
            });
        }

  
    }
}