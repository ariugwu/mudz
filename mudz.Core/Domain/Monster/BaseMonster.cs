﻿using System;
using System.Collections.Generic;
using mudz.Common.Domain;
using mudz.Common.Domain.GameEngine;
using mudz.Common.Domain.Inventory;
using mudz.Common.Domain.Monster;
using mudz.Core.Model.Domain;

namespace mudz.Core.Domain.Monster
{
    [Serializable]
    public abstract class BaseMonster : BaseActor, IMonster
    {
        protected BaseMonster()
        {
            GameObjectType = GameObjectTypes.Monster;
        }

        private double _dropRate = 0.10;

        public MonsterTypes MonsterType { get; set; }

        public override void TakeDamage(int dmg)
        {
            HitPoints = HitPoints - dmg;
        }

        public override void RestoreHealth(int health)
        {
            HitPoints = HitPoints + health;
        }

        public override int GetStaminaCostByActionType(GameActions gameAction)
        {
            throw new System.NotImplementedException("No monster should ever call this.");
        }

        public override int CalculateGameAction(GameActions gameAction)
        {
            return 10;
        }

        public IList<IInventoryItem> Inventory
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        IList<IInventoryItem> IMonster.Inventory
        {
            get { return Inventory; }
            set { Inventory = value; }
        }

        public bool HasItem(IInventoryItem item)
        {
            throw new System.NotImplementedException();
        }

        public double DropRate
        {
            get { return _dropRate; }
            set { _dropRate = value; }
        }

    }
}
