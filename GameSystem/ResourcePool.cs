using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_rpg.GameSystem
{
    public class ResourcePool
    {
        private ushort _max;

        public ResourcePool() : this(current: 1, max: 1) { }

        public ResourcePool(ushort current, ushort max)
        {
            _max = max;
            Current = Math.Min(_max, current);
        }

        public ushort Max 
        {
            get => _max;
            set 
            {
                if (value >= 1) 
                {
                    _max = value;
                    if (Current > _max) 
                        Current = _max;
                }   
            }
        }

        public ushort Current { get; private set; }

        public void Reduce(ushort amount) 
        {
            if (amount > Current)
            {
                Current = 0;
                return;
            }

            Current -= amount;
        }

        public void Increase(ushort amount) 
        {
            if (amount + Current > Max )
            { 
                Current = Max;
                return;
            }

            Current += amount;
        }
    }
}
