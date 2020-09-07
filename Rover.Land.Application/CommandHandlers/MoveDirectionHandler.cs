using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public static class MoveDirectionHandler
    {
        public static void Move(Rover.Land.Domain.Rover rover, Surface surface)
        {
            int x = rover.Position.Position_X;
            int y = rover.Position.Position_Y;
            switch (rover.Position.Direction)
            {
                case Direction.N:

                    if (IsValidMove(surface.Height, y++))
                        rover.Position.Position_Y += 1;
                    else
                        new Exception("Position must within Surface");
                    break;
                case Direction.S:
                    if (IsValidMove(surface.Height, y--))
                        rover.Position.Position_Y -= 1;
                    else
                        new Exception("Position must within Surface");
                    break;
                case Direction.E:
                    if (IsValidMove(surface.Height, x++))
                        rover.Position.Position_X += 1;
                    else
                        new Exception("Position must within Surface");
                    break;
                case Direction.W:
                    if (IsValidMove(surface.Height, x--))
                        rover.Position.Position_X -= 1;
                    else
                        new Exception("Position must within Surface");
                    break;
            }
        }
        public static bool IsValidMove(int surfaceBound, int position)
        {
            if (surfaceBound > position && position > -1)
                return true;
            return false;

        }
    }
}
