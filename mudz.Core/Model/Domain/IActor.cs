﻿namespace mudz.Core.Model.Domain
{
    public interface IActor : IGameObject
    {
        double Attack();
        double Heal();
        void Move();

        double Health { get; set; }
        double Strength { get; set; }
        double Intellect { get; set; }
        double Wisdom { get; set; }
        double Agility { get; set; }
        double Willpower { get; set; }
        double Charm { get; set; }
        double Endurance { get; set; }
    }
}
