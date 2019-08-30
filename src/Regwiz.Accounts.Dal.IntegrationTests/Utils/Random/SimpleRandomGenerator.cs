namespace Regwiz.Accounts.Dal.IntegrationTests.Utils.Random
{
    class SimpleRandomGenerator : IRandomGenerator
    {
        private readonly System.Random _rnd;
        private readonly int _current;

        public SimpleRandomGenerator() : this(0)
        {

        }

        public SimpleRandomGenerator(int seed)
        {
            _rnd = new System.Random(seed);
            _current = _rnd.Next();
        }

        public int GetSeed()
        {
            return _current;
        }
    }
}