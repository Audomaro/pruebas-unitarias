using Ninject;

using Sistema.Consola;

using System;
using System.Reflection;

namespace Sistema.ConsolaNinject
{

    internal class Program
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IStartUp programStarter = kernel.Get<IStartUp>();

            programStarter.Run();

            Console.Read();
        }
    }
}
