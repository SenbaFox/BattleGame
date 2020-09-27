using System;

namespace Model
{
    public class StartPhaseEventArgs : EventArgs
    {
        public Army Army;

        internal StartPhaseEventArgs(Army army)
            :base()
        {
            this.Army = army;
        }
    }
}
