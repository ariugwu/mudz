using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mudz.Core.Model.Domain.Player
{
    public class PlayerStates : GameObjectStates
    {
        public static PlayerStates Alive = new PlayerStates() { Name = "Alive", Description = ""};
        public static PlayerStates Infected = new PlayerStates() { Name = "Infected", Description = "" };
        public static PlayerStates Dead = new PlayerStates() { Name = "Dead", Description = "" };
        public static PlayerStates Drunk = new PlayerStates() { Name = "Drunk", Description = "" };
        public static PlayerStates Angry = new PlayerStates() { Name = "Angry", Description = "" };
        public static PlayerStates Depressed = new PlayerStates() { Name = "Depressed", Description = "" };
    }
}
