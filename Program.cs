using System;
using System.Runtime.Intrinsics.Arm;
using c__Project;

namespace c__Project
{
    class Program
    {

        static void Main(string[] args)
        {
            while(true)
            {
                Game game = new Game();
                game.Process();
            }
        }

    }
}

