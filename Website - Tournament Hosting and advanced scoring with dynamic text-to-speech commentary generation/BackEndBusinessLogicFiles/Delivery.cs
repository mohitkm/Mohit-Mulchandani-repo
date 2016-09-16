                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseConnectivity;

namespace BackendLogic
{
    public class Delivery
    {
        public int DeliveryID;
        public int DelNumber;
        public int BowlerID;
        public string DeliveryLength;
        public string DeliveryPosition;
        public int OnStrikePlayerID;
        public int OffStrikePlayerID;
        public string DeliveryType;
        public string StrikeType;
        public string StrikeDirection;
        public string StrikeElevation;
        public int Runs;
        public int ExtraType;
        public int DismissalType;
        public int DismissedPlayerID;
        public int ExtraRuns;
        public int FixtureID;
        public String Commentary;
    }
}
