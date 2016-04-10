using System;

namespace Chicken
{
    public class CoinEventArgs : EventArgs
    {
        private int oldCoin, newCoin;

        public int Old { get { return oldCoin; } }
        public int New { get { return newCoin; } }
        public CoinEventArgs(int oldCoin, int newCoin)
        {
            this.oldCoin = oldCoin;
            this.newCoin = newCoin;
        }
    }
}

