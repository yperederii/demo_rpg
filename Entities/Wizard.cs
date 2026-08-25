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
        public Wizard() : base(baseHp: 2, baseStr: 1, baseInt: 5) { }
    }
}
