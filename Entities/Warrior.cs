using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using demo_rpg.GameSystem;

namespace demo_rpg.Entities
{
    public class Warrior : BaseHero
    {
        public const ushort BASEHP = 5;
        public const ushort BASESTR = 5;
        public const ushort BASEINT = 2;

        const ushort LVLUPHEAL = 2;

        public Warrior() :
            base(baseHp: BASEHP, baseStr: BASESTR, baseInt: BASEINT) { }

        public override string GetClassName() { return "Warrior"; }

        protected override void LVLGain(ushort hp, ushort str, ushort intelligence)
        {
            base.LVLGain(hp, (ushort)(str + 1), intelligence);

            ushort hpHeal = (ushort)(Health.Max / LVLUPHEAL);
            Health.Increase(hpHeal); // warrior class heals with lvlups
                                     // - later move to cleric
        }
    }
}
