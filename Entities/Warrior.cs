using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using demo_rpg.GameSystem;

namespace demo_rpg.Entities
{
    public class Warrior : BaseHero
    {
        const ushort HPGROWTH = 5;
        const ushort STRGROWTH = 5;
        const ushort INTGROWTH = 1;

        const ushort LVLUPHEAL = 2;

        public Warrior() : 
            base(hpGrowth: HPGROWTH, baseStr: STRGROWTH, baseInt: INTGROWTH) { }

        public override void LVLUp()
        {
            base.LVLUp();
        }

        public override void LVLGain()
        {
            Health.MaxHP += HPGROWTH;

            ushort hpHeal = (ushort)(Health.MaxHP / LVLUPHEAL);
            Health.Heal(hpHeal); // warrior class heals with lvlups
                                 // - later move to cleric

            Stats.Strength += STRGROWTH;
            Stats.Intelligence += INTGROWTH;
        }
    }
}
