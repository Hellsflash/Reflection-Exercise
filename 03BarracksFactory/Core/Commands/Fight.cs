using _03BarracksFactory.Contracts;
using System;

namespace _03BarracksFactory.Core.Commands
{
    internal class Fight : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory)
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
            Environment.Exit(0);
            return string.Empty;
        }
    }
}