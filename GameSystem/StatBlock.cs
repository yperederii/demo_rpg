using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_rpg.GameSystem
{
    public class StatBlock
    {
        #region Levables attributes
        public ushort Strength { get; set; }
        public ushort Intelligence { get; set; }
        public ushort Agility { get; set; }
        #endregion

        #region Resistances
        public ushort PhysRes { get; set; }
        public ushort MageRes { get; set; }
        #endregion

        public StatBlock(ushort str = 1, ushort inl = 1, ushort agi = 1)
        {
            Strength = str;
            Intelligence = inl;
            Agility = agi;

            PhysRes = 0;
            MageRes = 0;
        }

    }
}
