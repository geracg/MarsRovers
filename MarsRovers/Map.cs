using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class Map : IMap
    {
        private Size _size;

        public Map(int w, int h)
        {
            this._size = new Size { W = h, H = h };
        }

        public bool CanMove(Position currentPos)
        {
            return CanMoveFrom(currentPos);
        }

        // Here we check if a given position is valid in the current map
        public bool IsValidPosition(Position pos)
        {
            return pos.X <= _size.W 
                && pos.Y <= _size.H 
                && pos.X >= 0 
                && pos.Y >= 0;
        }

        // here we check that we can move forward in the current direction
        // for example we cannot move forward outside the borders of the map
        private bool CanMoveFrom(Position pos)
        {
            switch (pos.heading)
            {
                case Heading.N:
                    return pos.Y < this._size.W;
                case Heading.E:
                    return pos.X < this._size.H;
                case Heading.S:
                    return pos.Y > 0;
                case Heading.W:
                    return pos.X > 0;
                default:
                    return false;
            }
        }
    }

    //a value object to represent Size of the map
    public struct Size
    {
        public int W;
        public int H;
    }
}
