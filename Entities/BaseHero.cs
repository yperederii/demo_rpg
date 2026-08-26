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
        public ushort CurrentLVL { get; protected set; } = 1;
        public UInt32 CurrentEXP { get; protected set; } = 0u;
        public UInt32 EXPtoNextLVL { get; protected set; } = 0u;
        public bool IsLevelable { get; protected set; } = false;

        public ushort BaseHP { get; set; } = 1;
        public ushort BaseSTR { get; set; } = 1;
        public ushort BaseINT { get; set; } = 1;

        public ResourcePool Health { get; protected set; }

        protected BaseHero(ushort baseHp, ushort baseStr, ushort baseInt) : base(baseStr, baseInt)
        {
            BaseHP = baseHp;
            Health = new ResourcePool(BaseHP, BaseHP);

            BaseSTR = baseStr;
            BaseINT = baseInt;
        }

        public abstract string GetClassName();

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

                LVLGain(BaseHP, BaseSTR, BaseINT);

                EXPtoNextLVL = CalculateExpToNextLVL(CurrentLVL);
            }
        }

        public UInt32 CalculateExpToNextLVL(ushort currentLVL) 
        {
            return (UInt32)(ILevelable.LVLScalar * Math.Pow(currentLVL, 2));
        }

        protected virtual void LVLGain(ushort hp, ushort str, ushort intelligence) 
        {
            Health.Max += (ushort)(hp / 2f);
            Strength += (ushort)(str / 2f);
            Intelligence += (ushort)(intelligence / 2f);
        }

        public virtual float GetEXPBonus() 
        {
            return 1.0f; //Method setup for futher exp scalar Items
        }
    }
}
