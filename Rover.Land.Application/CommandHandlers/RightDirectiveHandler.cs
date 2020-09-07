using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public static class RightDirectiveHandler
    {
        public static void TurnRight(Rover.Land.Domain.Rover rover)
        {
            if (rover.Position.Direction == Direction.W)
                rover.Position.Direction = Direction.N;
            else
                rover.Position.Direction = rover.Position.Direction + 1;
        }
    }
}
