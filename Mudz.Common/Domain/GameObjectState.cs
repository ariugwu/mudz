using System;

namespace Mudz.Common.Domain
{
    [Serializable]
    public class GameObjectState
    {
        public static GameObjectState InPlay = new GameObjectState(){ Name = "InPlay", Description = "InPlay"};
        public static GameObjectState OutOfPlay = new GameObjectState(){ Name = "OutOfPlay", Description = "OutOfPlay"};
        
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
