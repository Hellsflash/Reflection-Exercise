using _03BarracksFactory.Core.Commands;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;

    internal class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    Console.WriteLine("No such units in repository.");
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            var result = string.Empty;

            try
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => string.Equals(t.Name, commandName, StringComparison.CurrentCultureIgnoreCase));
                var command = (Command)Activator.CreateInstance(currentType, data, this.repository, this.unitFactory);
                result = command.Execute();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return result;
        }
    }
}