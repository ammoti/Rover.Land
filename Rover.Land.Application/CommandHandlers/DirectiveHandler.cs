using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public static class DirectiveHandler
    {
        public static IList<Directive> DirectiveList(string directives)
        {
            IList<Directive> directiveList = new List<Directive>();
            foreach (char item in directives.ToCharArray())
            {
                switch (item)
                {
                    case (char)Directive.RotateLeft:
                        directiveList.Add(Directive.RotateLeft);
                        break;
                    case (char)Directive.RotateRight:
                        directiveList.Add(Directive.RotateRight);
                        break;
                    case (char)Directive.MoveForward:
                        directiveList.Add(Directive.MoveForward);
                        break;
                }                
            }
            return directiveList;
        }
    }
}
