using System;

namespace mudz.Core.Model.Domain.Npc
{
    public abstract class Npc : BaseGameObject, INpc
    {
        //TO DO: Reserach constructor chaining!
        public Npc(string name)
        {
            Name = name;
            GameObjectType = GameObjectTypes.NPC;
        }

        public Npc()
        {
            GameObjectType = GameObjectTypes.NPC;
        }

        public NpcTypes NpcType { get; set; }

        // TO DO: Mark Abstract. Thanks Madeofcandy!

        public void Greet()
        {
            throw new NotImplementedException();
        }

        public void ProcessCommand()
        {
            throw new NotImplementedException();
        }

        public void Respond()
        {
            throw new NotImplementedException();
        }

        // TO DO: Put in default functionality for NPCs. While we want players to vary greatly that might not be the case here. 
        // Thanks Madeofcandy!

        public override void TakeDamage(double dmg)
        {
            throw new NotImplementedException();
        }

        public override void Heal(double health)
        {
            throw new NotImplementedException();
        }
    }
}
