using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    public class NavigationSystem
    {
        private IRover _rover;
        //created this dictionary to avoid using switch/case to know which command to execute
        private IDictionary<char, Func<Position>> _commands;

        public void RegisterRover(IRover rover)
        {
            this._rover = rover;
            RegisterRoverCommands();
        }

        //iterate over each command of the string, throws error if is invalid command
        public void ExecuteRoverCommands(string instructions)
        {
            var instructionsArray = instructions.ToArray();

            foreach (char com in instructionsArray)
            {
                try
                {
                    //if a command does not exist in the dictionary, it will throw an exception
                    _commands[com]();
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format($"Invalid command '{com}'"));
                }
            }

        }

        // This method is to associate each command with the provided character from input
        private void RegisterRoverCommands()
        {
            _commands = new Dictionary<char, Func<Position>>();

            _commands.Add('M', _rover.Move);
            _commands.Add('L', _rover.TurnLeft);
            _commands.Add('R', _rover.TurnRight);
        }
    }
}
