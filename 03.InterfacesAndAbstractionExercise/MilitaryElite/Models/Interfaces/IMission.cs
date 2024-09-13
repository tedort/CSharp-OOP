namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public string State { get; set; }
        public void CompleteMission();
    }
}
