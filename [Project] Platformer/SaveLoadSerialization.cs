using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Project__Platformer
{
    // 'coins' class with serializable constructors
    [Serializable]
    public class SaveLoadSerial_Coins
    {

        // coins constructor and serialization process
        //
        //

        public int Coins;

        public SaveLoadSerial_Coins() {} // empty constructor is required for serialization
    
        public SaveLoadSerial_Coins(int coins)
        {
            Coins += coins;
        }
    }

    // 'trophies' class with serializable constructors
    [Serializable]
    public class SaveLoadSerial_Trophies
    {
        // trophies constructor and serialization process
        //
        //

        public int A1 = 1;
        public int A2 = 2;

        public SaveLoadSerial_Trophies() { } //empty constructor is required for serialization

        public SaveLoadSerial_Trophies(int TrophyNum)
        {

        }
    }
}
