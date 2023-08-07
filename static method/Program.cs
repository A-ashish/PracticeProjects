using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace static_method // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "101";
            Console.WriteLine(s.EncloseHTML());
            Console.ReadLine();
        }
    }
    public static class stringExtension
    {
        public static string EncloseHTML(this string s)
        {
            return "<h1>" + s + "</h1>";
        }
    }
}