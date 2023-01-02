using Ninject;

using System;
using System.Reflection;

namespace Sistema.ConsolaNinject
{

    internal class Program : IProgram
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            StartUp programStarter = kernel.Get<StartUp>();

            programStarter.Run();

            Console.Read();
        }
    }
}
