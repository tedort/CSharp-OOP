using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new Dictionary<int, ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parts = input.Split();
                var type = parts[0];
                int id = int.Parse(parts[1]);
                string firstName = parts[2];
                string lastName = parts[3];

                switch (type)
                {
                    case "Private":
                        decimal salary = decimal.Parse(parts[4]);
                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        soldiers[id] = privateSoldier;
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(parts[4]);
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < parts.Length; i++)
                        {
                            int privateId = int.Parse(parts[i]);
                            lieutenantGeneral.AddPrivate((IPrivate)soldiers[privateId]);
                        }
                        soldiers[id] = lieutenantGeneral;
                        break;

                    case "Engineer":
                        salary = decimal.Parse(parts[4]);
                        string corps = parts[5];
                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string partName = parts[i];
                                int hoursWorked = int.Parse(parts[i + 1]);
                                engineer.AddRepair(new Repair(partName, hoursWorked));
                            }
                            soldiers[id] = engineer;
                        }
                        catch (ArgumentException)
                        {
                            // Invalid corps, skip this engineer
                        }
                        break;

                    case "Commando":
                        salary = decimal.Parse(parts[4]);
                        corps = parts[5];
                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string codeName = parts[i];
                                string state = parts[i + 1];
                                try
                                {
                                    commando.AddMission(new Mission(codeName, state));
                                }
                                catch (ArgumentException)
                                {
                                    // Invalid mission state, skip this mission
                                }
                            }
                            soldiers[id] = commando;
                        }
                        catch (ArgumentException)
                        {
                            // Invalid corps, skip this commando
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(parts[4]);
                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers[id] = spy;
                        break;
                }
            }

            foreach (var soldier in soldiers.Values)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
