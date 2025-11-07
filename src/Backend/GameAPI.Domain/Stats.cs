namespace GameAPI.Domain
{
    public class Stats
    {
        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int Health { get; private set; }

        private Stats()
        {
            
        }

        public Stats(int level, int xp, int hp)
        {
            Level = level;
            Experience = xp;
            Health = hp;
        }

        public Stats GainXp(int xp)
        {
            int newXp = Experience + xp;
            int newLevel = Level;

            if(newXp >= 100)
            {
                newLevel = newLevel + (newXp / 100);
                newXp = newXp % 100;
            }
            return new Stats(newLevel, newXp, Health);
        }
    }
}
