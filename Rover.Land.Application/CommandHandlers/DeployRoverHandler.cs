using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public class DeployRoverHandler
    {
        private int xPos { get; set; }
        private int yPos { get; set; }
        public Direction direction { get; set; }
        public Rover.Land.Domain.Rover DeployRover(string initialPosition)
        {
            if (!string.IsNullOrEmpty(initialPosition))
            {
                string[] position = initialPosition.Split(' ');
                xPos = int.Parse(position[0]);
                yPos = int.Parse(position[1]);
                direction = (Direction)Enum.Parse(typeof(Direction), position[2]);
                Position roverPosition = new Position { Position_X = xPos, Position_Y = yPos, Direction = direction };
                Rover.Land.Domain.Rover newRover = new Domain.Rover { RoverName = Guid.NewGuid().ToString().Substring(0, 5), Position = roverPosition };
                return newRover;
            }
            return null;
        }
    }
}