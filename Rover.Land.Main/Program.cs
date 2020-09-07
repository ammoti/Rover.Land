using System;
using System.Collections.Generic;
using Rover.Land.Application.CommandHandlers;
using Rover.Land.Domain.Enums;

namespace Rover.Land.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome on the Mars Rover Land Program");

            Console.WriteLine("Please set the surface size Eg:3 5");
            string surfaceSize = Console.ReadLine();

            SurfaceHandler surface = new SurfaceHandler();
            var plateau = surface.CreateSurface(surfaceSize);
            Console.WriteLine($"Surface width : {plateau.Width} and height : {plateau.Height}");

            Dictionary<Domain.Rover, List<Domain.Enums.Directive>> roverList = new Dictionary<Domain.Rover, List<Domain.Enums.Directive>>();

            while (true)
            {
                var (rover, directiveList) = AddRover();
                roverList.Add(rover, (List<Domain.Enums.Directive>)directiveList);

                System.Console.WriteLine("Do you want to add new rover to plateau ? (Y/N)");
                var answer = Console.ReadLine();
                if (answer == "N")
                { MoveRover(roverList, plateau); break; }
            }
        }

        private static void MoveRover(Dictionary<Domain.Rover, List<Directive>> roverList, Domain.Surface plateau)
        {
            foreach (var pair in roverList)
            {
                foreach (var item in pair.Value)
                {
                    if (item == Domain.Enums.Directive.RotateRight)
                        RightDirectiveHandler.TurnRight(pair.Key);
                    else if (item == Domain.Enums.Directive.MoveForward)
                        MoveDirectionHandler.Move(pair.Key, plateau);
                    else if (item == Domain.Enums.Directive.RotateLeft)
                        LeftDirectiveHandler.TurnLeft(pair.Key);
                    System.Console.WriteLine($"RoverInfo X  {pair.Key.Position.Position_X} rover Y {pair.Key.Position.Position_Y} orientation {pair.Key.Position.Direction.ToString()}");
                }
                System.Console.WriteLine($"RoverInfo {pair.Key.Position.Direction}");
                System.Console.WriteLine($"x Pos {pair.Key.Position.Position_X} y Pos {pair.Key.Position.Position_Y}");
            }
        }

        private static (Domain.Rover, IList<Domain.Enums.Directive> directives) AddRover()
        {
            Console.WriteLine("Please set the initial rover position Eg:1 2 N");
            string initialPosition = Console.ReadLine();

            DeployRoverHandler deploy = new DeployRoverHandler();
            var rover = deploy.DeployRover(initialPosition);

            Console.WriteLine("Please set the rover move list Eg:LLRMMRL");
            string directiveList = Console.ReadLine();
            var directives = DirectiveHandler.DirectiveList(directiveList);

            return (rover, directives);
        }
    }
}
