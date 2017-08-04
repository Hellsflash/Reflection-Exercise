using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().SingleOrDefault(t => t.Name == unitType);

            return (IUnit)Activator.CreateInstance(type);
        }
    }
}