namespace DiceGame
{
    class Dice
    {
        private readonly int maxSides;
        private readonly Random random;
        public int Value { get; set; }

        public Dice(int maxSides, Random random)
        {
            this.maxSides = maxSides;
            this.random = random;
            Roll();
        }

        // Roll dice and update value
        public void Roll()
        {
            Value = random.Next(1, maxSides + 1);
        }
    }
}
