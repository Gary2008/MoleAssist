using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoleAssist
{
    public static class FightControl
    {
        static FightControl() {
            isFighting = false;
        }
 
        public static bool isFighting { get; set; }

        public static void Start() {
            isFighting = true;
            //TODO: start fight processing
        }
        public static void Stop()
        {
            isFighting = true;
            //TODO: stop fight processing
        }
    }
}
