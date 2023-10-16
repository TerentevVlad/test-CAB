namespace Game.Units.Fruit
{
    public class FruitConfig
    {
        public FruitView FruitViewPrefab { get; }
        public int InitialFruits { get; }
        public int MaxFruits { get; }
        public float CooldownRespawn { get; }

        public FruitConfig(FruitView fruitViewPrefab, int initialFruits, int maxFruits, float cooldownRespawn)
        {
            FruitViewPrefab = fruitViewPrefab;
            InitialFruits = initialFruits;
            MaxFruits = maxFruits;
            CooldownRespawn = cooldownRespawn;
        }
    }
}