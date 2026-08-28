using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_rpg.GameSystem;

namespace demo_rpg.Entities
{
    public abstract class BaseHero : StatBlock, ILevelable
    {
        public abstract string ClassName { get; }

        #region Leveling
        public ushort CurrentLVL { get; protected set; } = 1;
        public UInt32 CurrentEXP { get; protected set; } = 0u;
        public UInt32 EXPtoNextLVL { get; protected set; } = 0u;
        public bool IsLevelable { get; protected set; } = false;
        #endregion

        #region Attributes
        public ushort BaseHP { get; set; } = 1;
        public ushort BaseMP { get; set; } = 1;
        public ushort BaseSTR { get; set; } = 1;
        public ushort BaseINT { get; set; } = 1;
        public ushort BaseAGI { get; set; } = 1;
        #endregion

        #region Vitals
        public ResourcePool Health { get; protected set; }
        public ResourcePool Mana { get; protected set; }
        #endregion

        protected BaseHero(ushort baseHp, ushort baseMp, 
            ushort baseStr, ushort baseInt, ushort baseAgi) 
            : base(baseStr, baseInt, baseAgi)
        {
            BaseHP = baseHp;
            Health = new ResourcePool(BaseHP, BaseHP);

            BaseMP = baseMp;
            Mana = new ResourcePool(BaseMP, BaseMP);

            BaseSTR = baseStr;
            BaseINT = baseInt;
            BaseAGI = baseAgi;
        }

        public void GainEXP(UInt32 gainedEXP) 
        {
            gainedEXP = (UInt32)Math.Round(gainedEXP * GetEXPBonus());

            CurrentEXP += gainedEXP;

            if (CurrentEXP >= EXPtoNextLVL) 
            {
                LVLUp();
            }
        }

        protected virtual void LVLUp() 
        {
            while (CurrentEXP >= EXPtoNextLVL) 
            {
                CurrentEXP -= EXPtoNextLVL;
                CurrentLVL++;

                LVLGain(BaseHP, BaseMP, BaseSTR, BaseINT, BaseAGI);

                EXPtoNextLVL = CalculateExpToNextLVL(CurrentLVL);
            }
        }

        public UInt32 CalculateExpToNextLVL(ushort currentLVL) 
        {
            return (UInt32)(ILevelable.LVLScalar * Math.Pow(currentLVL, 2));
        }

        protected virtual void LVLGain(ushort hp, ushort mp, ushort str, ushort inl, ushort agi) 
        {
            Health.Max += (ushort)(hp / 2f);
            Mana.Max += (ushort)(mp / 2f);
            Strength += (ushort)(str / 2f);
            Intelligence += (ushort)(inl / 2f);
            Agility += (ushort)(agi / 2f);
        }

        public virtual float GetEXPBonus() 
        {
            return 1.0f; //Method setup for futher exp scalar Items
        }
    }
}
