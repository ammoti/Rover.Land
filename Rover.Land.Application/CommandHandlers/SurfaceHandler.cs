using System;
using System.Collections.Generic;
using Rover.Land.Domain;
using Rover.Land.Domain.Enums;
namespace Rover.Land.Application.CommandHandlers
{
    public class SurfaceHandler
    {

        private int width { get; set; }
        private int height { get; set; }
        public Surface CreateSurface(string surface)
        {
            if (!string.IsNullOrEmpty(surface))
            {
                string[] surfaceSize = surface.Split(' ');
                width = int.Parse(surfaceSize[0]);
                height = int.Parse(surfaceSize[1]);

                if (width > 0 && height > 0)
                {
                    Surface newSurface = new Surface { Height = height, Width = width };
                    return newSurface;
                }
                else
                    return null;
            }
            return null;
        }
    }
}
