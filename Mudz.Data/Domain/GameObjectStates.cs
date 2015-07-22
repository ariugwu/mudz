using System;

namespace Mudz.Data.Domain
{
    [Serializable]
    public class GameObjectStates
    {
        public static GameObjectStates InPlay = new GameObjectStates(){ Name = "InPlay", Description = "InPlay"};
        public static GameObjectStates OutOfPlay = new GameObjectStates(){ Name = "OutOfPlay", Description = "OutOfPlay"};
        
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
