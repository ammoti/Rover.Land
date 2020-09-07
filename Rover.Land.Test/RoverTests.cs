using System;
using Xunit;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
using Rover.Land.Application.CommandHandlers;

namespace Rover.Land.Test
{
    public class RoverTests
    {
        [InlineData(new object[] { "5 5" })]
        [Theory]
        public void Test_CreateSurface(string size)
        {
            SurfaceHandler _surfaceHandler = new SurfaceHandler();
            var surface = _surfaceHandler.CreateSurface(size);
            Assert.NotNull(surface);
        }
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM" })]
        [Theory]
        public void Test_MoveRover(string size, string initialPosition, string directionList)
        {
            SurfaceHandler _surfaceHandler = new SurfaceHandler();
            var surface = _surfaceHandler.CreateSurface(size);
            DeployRoverHandler deploy = new DeployRoverHandler();
            var rover = deploy.DeployRover(initialPosition);
            Console.WriteLine("Rover Test", rover.Position.Position_X.ToString());
            string directiveList = directionList;
            var directives = DirectiveHandler.DirectiveList(directiveList);
            foreach (var item in directives)
            {
                if (item == Domain.Enums.Directive.RotateRight)
                    RightDirectiveHandler.TurnRight(rover);
                else if (item == Domain.Enums.Directive.MoveForward)
                    MoveDirectionHandler.Move(rover, surface);
                else if (item == Domain.Enums.Directive.RotateLeft)
                    LeftDirectiveHandler.TurnLeft(rover);
            }
            Assert.Equal(1, rover.Position.Position_X);
            Assert.Equal(3, rover.Position.Position_Y);
            Assert.Equal(Direction.N, rover.Position.Direction);
        }
          [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM" })]
        [Theory]
        public void Test_MoveRover2(string size, string initialPosition, string directionList)
        {
            SurfaceHandler _surfaceHandler = new SurfaceHandler();
            var surface = _surfaceHandler.CreateSurface(size);
            DeployRoverHandler deploy = new DeployRoverHandler();
            var rover = deploy.DeployRover(initialPosition);
            Console.WriteLine("Rover Test", rover.Position.Position_X.ToString());
            string directiveList = directionList;
            var directives = DirectiveHandler.DirectiveList(directiveList);
            foreach (var item in directives)
            {
                if (item == Domain.Enums.Directive.RotateRight)
                    RightDirectiveHandler.TurnRight(rover);
                else if (item == Domain.Enums.Directive.MoveForward)
                    MoveDirectionHandler.Move(rover, surface);
                else if (item == Domain.Enums.Directive.RotateLeft)
                    LeftDirectiveHandler.TurnLeft(rover);
            }
            Assert.Equal(5, rover.Position.Position_X);
            Assert.Equal(1, rover.Position.Position_Y);
            Assert.Equal(Direction.E, rover.Position.Direction);
        }

    }
}
