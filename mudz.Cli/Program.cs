﻿using System;
using System.Collections.Generic;
using System.Linq;
using mudz.Core.Model.Domain;
using mudz.Core.Model.Domain.Environment.Map;
using mudz.Core.Model.Domain.Environment.Map.Room;
using mudz.Core.Model.Domain.GameEngine;
using mudz.Core.Model.Domain.Monster;
using mudz.Core.Model.Domain.Npc;
using mudz.Core.Model.Domain.Player;
using mudz.Core.Model.Domain.Player.Inventory.Item.Keepsake;
using mudz.Core.Model.Domain.Player.Inventory.Item.Weapon;
using mudz.Core.Model.Domain.Player.Inventory.Item.Wearable;

namespace mudz.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var hiveMind = new HiveMind();

            var room = hiveMind.World.Rooms.First().Value;

            var gary = (IPlayer)room.GameObjects.First(x => x.Name == "Gary");

                gary.AddInventoryItem(new TestCharm());

            var beth = room.GameObjects.First(x => x.Name == "Beth");

            var response = hiveMind.Execute(new GameRequest() {GameAction = GameActions.Heal, Sender = gary, Target = beth});

            Console.WriteLine(response.Message);
            Console.ReadKey();

            //var morgan = room.Npcs.First(x => x.Name == "Morgan");
            //var deputy = room.Npcs.First(x => x.Name == "SlowDraw");

            //var zombie = room.Monsters.First();

            //var hammer = new TestHammer();
            //var gloves = new TestGloves();
            //var hat = new TestHat();
            //var charm = new TestCharm();
            //var secondHammer = new TestHammer();
            //var secondCharm = new TestCharm();

            //var dmg = gary.Fight();

            //Console.WriteLine("{0} attacks for {1} damage!", gary.GetName(), dmg);
            //Console.ReadKey();

            //gary.EquipWeapon(hammer);
            //gary.EquipWearable(gloves);
            //gary.EquipWearable(hat);
            //gary.AddInventoryItem(charm);

            //gary.AddInventoryItem(secondHammer); 
            //gary.AddInventoryItem(secondCharm);

            //Console.WriteLine("{0} puts on his sunday best.", gary.GetName());
            //dmg = gary.Fight();

            //Console.WriteLine("{0} attacks for {1} damage!", gary.GetName(), dmg);
            //Console.ReadKey();



            //Console.WriteLine(gary.GetDescription());

            //Console.WriteLine("{0} says \"{1}\"", morgan.Name, morgan.Greet());

            //Console.ReadKey();

            //Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);

            //dmg = zombie.Fight();

            //morgan.TakeDamage(dmg);

            //Console.WriteLine("{0} takes {1} damage!", morgan.Name, dmg);
            //Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);
            //Console.ReadKey();

            //double heal = beth.Heal();

            //Console.WriteLine("{0} moves to heal {1}", beth.GetName(), morgan.Name);

            //morgan.RestoreHealth(heal);

            //Console.ReadKey();
            //Console.WriteLine("{0} heals {1} for {2} hit points!", beth.GetName(), morgan.Name, heal);
            //Console.ReadKey();

            //heal = gary.Heal();
            //Console.WriteLine("{0} moves to heal {1}", gary.GetName(), morgan.Name);
            //Console.ReadKey();

            //morgan.RestoreHealth(heal);
            //Console.WriteLine("{0} heals {1} for {2} hit points!", gary.GetName(), morgan.Name, heal);

            //Console.ReadKey();

            //Console.WriteLine("{0} is a {1}. (S)He has {2} hit points.", morgan.Name, morgan.NpcType, morgan.HitPoints);

            //Console.ReadKey();
        }
    }
}
