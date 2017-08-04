namespace _03BarracksFactory.Models.Units
{
    internal class Horseman : Unit
    {
        private const int DefaultHealth = 40;
        private const int DefaultDamage = 13;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}