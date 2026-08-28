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
        public Warrior() :
            base(baseHp: 5, baseMp: 1, baseStr: 5, baseInt: 1, baseAgi: 2) { }

        public override string ClassName => "Warrior";

        protected override void LVLGain(ushort hp, ushort mp, ushort str, ushort inl, ushort agi)
        {
            base.LVLGain(hp, mp, (ushort)(str + 1), inl, agi);

            const ushort LVLUPHEAL = 2;
            ushort hpHeal = (ushort)(Health.Max / LVLUPHEAL);
            Health.Increase(hpHeal); // warrior class heals with lvlups
                                     // - later move to cleric
        }
    }
}
