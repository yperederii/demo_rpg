using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_rpg.GameSystem;

namespace demo_rpg.Entities
{
    public abstract class BaseHero : ILevelable
    {
        public ushort CurrentLVL { get; protected set; } = 1;
        public UInt32 CurrentEXP { get; protected set; } = 0u;
        public UInt32 EXPtoNextLVL { get; protected set; } = 0u;
        public bool IsLevelable { get; protected set; } = false;

        public ushort BaseSTR { get; protected set; }
        public ushort BaseINT { get; protected set; }
        public ushort HPGrowth { get; protected set; }

        public HP Health { get; protected set; }
        public StatBlock Stats { get; protected set; }

        protected BaseHero(ushort hpGrowth, ushort baseStr, ushort baseInt)
        {
            HPGrowth = hpGrowth;
            BaseSTR = baseStr;
            BaseINT = baseInt;

            Health = new HP(HPGrowth, HPGrowth);
            Stats = new StatBlock(strength: BaseSTR, intelligence: BaseINT);
        }

        public void GainEXP(UInt32 gainedEXP) 
        {
            gainedEXP = (UInt32)Math.Round(gainedEXP * GetEXPBonus());

            CurrentEXP += gainedEXP;

            if (CurrentEXP >= EXPtoNextLVL) 
            {
                IsLevelable = true;
            }
        }

        public virtual void LVLUp() 
        {
            if (!IsLevelable) return;

            while (CurrentEXP >= EXPtoNextLVL) 
            {
                CurrentEXP -= EXPtoNextLVL;
                CurrentLVL++;

                LVLGain();

                EXPtoNextLVL = CalculateExpToNextLVL(CurrentLVL);
            }

            IsLevelable = false;
        }

        public UInt32 CalculateExpToNextLVL(ushort currentLVL) 
        {
            return (UInt32)(ILevelable.LVLScalar * Math.Pow(currentLVL, 2));
        }

        public virtual void LVLGain() { }

        public virtual float GetEXPBonus() 
        {
            return 1.0f; //Method setup for futher exp scalar Items
        }
    }
}
