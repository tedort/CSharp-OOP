namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        public NaturalClimber(string name) : base(name, 6)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * 2;
        }
    }
}
