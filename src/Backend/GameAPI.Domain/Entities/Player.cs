namespace GameAPI.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string? Username{ get; private set; }
        public Stats? Stats{ get; private set; }

        private Player() { }

        public Player(string username)
        {
            Username = username;
            Stats = new Stats(1, 0, 100);

        }

        public void GainExperience(int xp)
        {
            Stats = Stats!.GainXp(xp);
        }
    }
}
