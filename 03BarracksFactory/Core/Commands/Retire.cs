using _03BarracksFactory.Contracts;
using System;

namespace _03BarracksFactory.Core.Commands
{
    internal class Retire : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get => repository;
            set => repository = value;
        }

        public IUnitFactory UnitFactory
        {
            get => unitFactory;
            set => unitFactory = value;
        }

        public override string Execute()
        {
            var unitType = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return String.Format($"{unitType} retired!");
            }
            catch (ArgumentException arg)
            {
                return arg.Message;
            }
        }
    }
}