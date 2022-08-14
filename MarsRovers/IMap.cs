using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public interface IMap
    {
        bool CanMove(Position currentPos);
        bool IsValidPosition(Position pos);
    }
}
