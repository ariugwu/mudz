﻿using System;

namespace mudz.Core.Model.Domain.Player
{
    public class Carpenter : IPlayerActionStrategy
    {
        public double Attack()
        {
            throw new NotImplementedException();
        }

        public double Heal()
        {
            return 5;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Inspect()
        {
            throw new NotImplementedException();
        }

        public void Repair()
        {
            throw new NotImplementedException();
        }

        public void Negotiate()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(double dmg)
        {
            throw new NotImplementedException();
        }

        public void Heal(double health)
        {
            throw new NotImplementedException();
        }
    }
}
