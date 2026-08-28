using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_rpg.GameSystem;

namespace demo_rpg.Entities
{
    public class Wizard : BaseHero
    {
        public Wizard() :
            base(baseHp: 2, baseMp: 5, baseStr: 2, baseInt: 5, baseAgi: 1) { }

        public override string ClassName => "Wizzard";

        protected override void LVLGain(ushort hp, ushort mp, ushort str, ushort inl, ushort agi)
        {
            base.LVLGain(hp, mp, str, (ushort)(inl + 1), agi);

            const ushort MPGAIN = 2;
            ushort hpHeal = (ushort)(Mana.Max / MPGAIN);
            Mana.Increase(hpHeal);
        }
    }
}
