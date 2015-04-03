using System;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var gary = PlayerFactory.Create("Gary", PlayerTypes.Politician);
            var beth = PlayerFactory.Create("Beth", PlayerTypes.ArmyVet);

            var townsperson = NpcFactory.Create("Morgan", NpcTypes.TownsPerson);
            var deputy = NpcFactory.Create("SlowDraw", NpcTypes.Deputy);

            Console.ReadKey();
        }
    }
}
