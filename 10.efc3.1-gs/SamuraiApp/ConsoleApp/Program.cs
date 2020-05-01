using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace ConsoleApp
{
    class Program
    {
        private static SamuraiContext context = new SamuraiContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            Console.Write("Press any key");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Victor" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        static void GetSamurais(string message)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{message} : Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
