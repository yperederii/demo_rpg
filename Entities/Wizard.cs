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
        public const ushort BASEHP = 2;
        public const ushort BASESTR = 2;
        public const ushort BASEINT = 5;

        public Wizard() :
            base(baseHp: BASEHP, baseStr: BASESTR, baseInt: BASEINT) { }

        public override string GetClassName() { return "Wizzard"; }

        protected override void LVLGain(ushort hp, ushort str, ushort intelligence)
        {
            base.LVLGain(hp, str, (ushort)(intelligence + 1));
        }
    }
}
