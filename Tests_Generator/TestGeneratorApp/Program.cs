using System;
using TestGeneratorApp.Block;

namespace TestGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = @"..\..\Tests\Source";
            var dest = @"..\..\Tests\Result";
            var files = new string[] { "T1.cs", "T2.cs" };
            var countTasks = 2;

            new Generator().Generate(src, dest, files, countTasks); 
            Console.WriteLine("Success!");
        }
    }
}
