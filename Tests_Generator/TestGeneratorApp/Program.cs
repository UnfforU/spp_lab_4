using System;
using TestGeneratorApp.Block;

namespace TestGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = @"..\..\..\Tests\Source";
            var files = new string[] { "T1.cs", "T3.cs" };
            var dest = @"..\..\..\Tests\Result";
            var countTasks = 2;

            new Generator().Generate(src, dest, files, countTasks); 
            //Console.WriteLine("Success!");
            Console.ReadLine();
        }
    }
}
