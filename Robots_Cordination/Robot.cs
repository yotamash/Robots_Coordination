using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots_Cordination
{
    internal class Robot
    {
        int[] finalKey;
        int keySize;
        Random rnd = new Random();

        public Robot(int keySize)
        {
            this.keySize = keySize;
            finalKey = new int[keySize];
        }

        private int GuessBase()
        {
            return rnd.Next(2);
        }

        public bool CheckBase(int key)
        {
            int newKeyBit = GuessBase();
            if (newKeyBit == key)
            {
                return true;
            }
            return false;
        }
    }
}

