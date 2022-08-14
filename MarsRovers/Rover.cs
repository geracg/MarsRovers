using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class Rover : IRover
    {
        private IMap _map;
        private Position _currentPosition;

        //Throws error if position is invalid
        public Rover(IMap map, Position position)
        {
            if (!map.IsValidPosition(position)) 
                throw new Exception(String.Format($"X:{position.X} Y:{position.Y} Z:{position.heading} is not a valid position in map"));

            this._map = map;
            this._currentPosition = position;
        }

        public Position Position { get { return _currentPosition; } }

        public Position Move()
        {
            DoMove();
            return this._currentPosition;
        }

        public Position TurnRight()
        {
            this._currentPosition.heading = CardinalDirectionsUtilities.TurnRightFrom(_currentPosition.heading);
            return this._currentPosition;
        }

        public Position TurnLeft()
        {
            this._currentPosition.heading = CardinalDirectionsUtilities.TurnLeftFrom(_currentPosition.heading);
            return this._currentPosition;
        }

        //If can move forward in the map, it will move one position.
        private void DoMove()
        {
            if (_map.CanMove(_currentPosition))
            {
                switch (_currentPosition.heading)
                {
                    case Heading.N:
                        _currentPosition.Y++;
                        break;
                    case Heading.E:
                        _currentPosition.X++;
                        break;
                    case Heading.S:
                        _currentPosition.Y--;
                        break;
                    case Heading.W:
                        _currentPosition.X--;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // class representing a given position
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Heading heading { get; set; }

        public override string ToString()
        {
            return string.Format($"{X} {Y} {heading}");
        }
    }
}
