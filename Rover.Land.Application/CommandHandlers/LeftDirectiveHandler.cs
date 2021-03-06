using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public static class LeftDirectiveHandler
    {
        public static void TurnLeft(Rover.Land.Domain.Rover rover)
        {
            if (rover.Position.Direction == Direction.N)
                rover.Position.Direction = Direction.W;
            else
                rover.Position.Direction = rover.Position.Direction - 1;
        }
    }
}
