namespace MarsRovers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines;
            NavigationSystem ns;
            IMap map;

            try
            {
                // Put the input test in the Inputs.txt file at the root of the project
                lines = Program.ReadFromInputTxt("../../../Inputs.txt");
                var mapSize = lines[0].Split(" ");
                ns = new NavigationSystem();
                map = new Map(int.Parse(mapSize[0]), int.Parse(mapSize[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to initialize - {e.Message}");
                return;
            }
            
            var result = "";

            //we iterate in increments of 2 to take 2 lines each iteration, starting at second line,
            //we create a new Rover for each set of commands
            for (int i = 1; i < lines.Length; i+=2)
            {
                try
                {
                    Position initialPosition = GetPositionFromString(lines[i].ToUpper());
                    string commands = lines[i + 1].ToUpper();

                    IRover rover = new Rover(map, initialPosition);
                    result = RunCommandsOnRover(ns, commands, rover);
                }
                catch (IndexOutOfRangeException e)
                {
                    result = $"Invalid input at line {i + 1} in Inputs file";
                    i = lines.Length;
                }
                catch (Exception e)
                {
                    result = e.Message;
                    i = lines.Length;
                }
                
                Console.WriteLine(result);
            }
        }

        private static string RunCommandsOnRover(NavigationSystem ns, string commands, IRover rover)
        {
            string result;
            ns.RegisterRover(rover);
            ns.ExecuteRoverCommands(commands);
            result = rover.Position.ToString();
            return result;
        }

        //method to create Position object from string, throw exception if is invalid
        private static Position GetPositionFromString(string str)
        {
            try
            {
                var strArr = str.Split(" ");
                Position p = new Position();
                p.X = int.Parse(strArr[0]);
                p.Y = int.Parse(strArr[1]);
                p.heading = Enum.Parse<Heading>(strArr[2]);
                return p;
            }
            catch (Exception)
            {
                throw new Exception($"Invalid format for position values: '{str}'");
            }
            
        }

        private static string[] ReadFromInputTxt(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}