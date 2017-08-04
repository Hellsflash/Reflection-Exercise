using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    internal class Report : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public Report(string[] data, IRepository repository, IUnitFactory unitFactory)
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
            var output = this.Repository.Statistics;
            return output;
        }
    }
}