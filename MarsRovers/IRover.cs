using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public interface IRover
    {
        Position Position { get; }
        Position TurnRight();
        Position TurnLeft();
        Position Move();
    }
}
