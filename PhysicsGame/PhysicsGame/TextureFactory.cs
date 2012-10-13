#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace PhysicsGame
{
    class TextureFactory
    {
        GraphicsDevice GDevice;

        public TextureFactory(GraphicsDevice device)
        {
            GDevice = device;
        }

        public Texture2D GenerateCircleTexture(int radius, Color color)
        {
            int diameter = radius*2;

            Texture2D circle = new Texture2D(GDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];
            Vector2 center = new Vector2(radius, radius);

            for (int i = 0; i < diameter; i++)
            {
                for (int j = 0; j < diameter; j++)
                {
                    Vector2 pt = new Vector2(i, j);
                    if ((center - pt).Length() < radius)
                    {
                        data[diameter * i + j] = Color.White;
                    }
                }
            }
            circle.SetData(data);
            return circle;
        }
    }
}
