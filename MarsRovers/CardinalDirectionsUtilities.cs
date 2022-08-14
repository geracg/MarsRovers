using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    internal class CardinalDirectionsUtilities
    {
        //Utility class to calculate new directions when turning right or left
        public static Heading TurnRightFrom(Heading headFrom)
        {
            switch (headFrom)
            {
                case Heading.N:
                    return Heading.E;
                case Heading.E:
                    return Heading.S;
                case Heading.S:
                    return Heading.W;
                case Heading.W:
                    return Heading.N;
                default:
                    return headFrom;
            }
        }

        public static Heading TurnLeftFrom(Heading headFrom)
        {
            switch (headFrom)
            {
                case Heading.N:
                    return Heading.W;
                case Heading.E:
                    return Heading.N;
                case Heading.S:
                    return Heading.E;
                case Heading.W:
                    return Heading.S;
                default:
                    return headFrom;
            }
        }
    }

    //enum representing the Cardinal directions
    public enum Heading
    {
        N, E, S, W
    }
}
