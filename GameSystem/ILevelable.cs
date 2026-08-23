using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_rpg.GameSystem
{
    public interface ILevelable
    {
        protected const UInt32 LVLScalar = 10;

        ushort CurrentLVL { get; }
        UInt32 CurrentEXP { get; }
        UInt32 EXPtoNextLVL { get; }
        bool IsLevelable { get; }

        void GainEXP(UInt32 gainedEXP);
        void LVLUp();
        UInt32 CalculateExpToNextLVL(ushort currentLVL);
        float GetEXPBonus();

        // lvl 1 = 0 exp
        // lvl 2 = 10 * 2^2
        //       = 40
        // lvl 3 = 10 * 3^2
        //       = 90
        // lvl 4 = 10 * 4^2
        //       = 160
    }
}
