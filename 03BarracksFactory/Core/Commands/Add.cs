using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    internal class Add : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public Add(string[] data, IRepository repository, IUnitFactory unitFactory)
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
            var unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            var output = unitType + " added!";
            return output;
        }
    }
}