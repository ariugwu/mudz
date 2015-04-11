using System;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {

            var gary = PlayerFactory.Create("Gary", PlayerTypes.Politician);
            var beth = PlayerFactory.Create("Beth", PlayerTypes.Medic);

            var morgan = NpcFactory.Create("Morgan", NpcTypes.TownsPerson);
            var deputy = NpcFactory.Create("SlowDraw", NpcTypes.Deputy);

            var zombie = MonsterFactory.Create(MonsterTypes.Zombie);

            Console.WriteLine(gary.Health);

            Console.WriteLine("{0} says \"{1}\"", morgan.Name, morgan.Greet());

            Console.ReadKey();

            Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);

            double dmg = zombie.Fight();
            
            morgan.TakeDamage(dmg);

            Console.WriteLine("{0} takes {1} damage!", morgan.Name, dmg);
            Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);
            Console.ReadKey();

            double heal = beth.Heal();

            Console.WriteLine("{0} moves to heal {1}", beth.Name, morgan.Name);

            morgan.RestoreHealth(heal);

            Console.ReadKey();
            Console.WriteLine("{0} heals {1} for {2} hit points!", beth.Name, morgan.Name, heal);
            Console.ReadKey();

            heal = gary.Heal();
            Console.WriteLine("{0} moves to heal {1}", gary.Name, morgan.Name);
            Console.ReadKey();

            morgan.RestoreHealth(heal);
            Console.WriteLine("{0} heals {1} for {2} hit points!", gary.Name, morgan.Name, heal);

            Console.ReadKey();

            Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);

            Console.ReadKey();
        }
    }
}
