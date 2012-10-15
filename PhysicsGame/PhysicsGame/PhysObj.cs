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
    abstract class PhysObj
    {
        #region Physics Constants
        float gravity = 0.5f;
        protected float bounce = 0.8f;
        #endregion

        protected Texture2D Texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public Point Size;
        public float Mass;

        public PhysObj(Texture2D texture, Vector2 position, Vector2 velocity, float mass)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Mass = mass;

            Size = new Point(Texture.Bounds.Width, Texture.Bounds.Height);
        }

        public virtual void Update()
        {
            Velocity.Y += gravity;
            Position += Velocity;

            //check collision with ground
            if (Position.Y > 720 - 100 - Size.Y)
            {
                Position.Y = 720 - 100 - Size.Y;
                Velocity.Y *= -bounce;
            }
            else if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y *= -bounce;
            }
            // check collision with walls
            if (Position.X < 0)
            {
                Position.X = 0;
                Velocity.X *= -bounce;
            }
            else if (Position.X > 1280 - Size.X)
            {
                Position.X = 1280 - Size.X;
                Velocity.X *= -bounce;
            }

        }

        public Vector2 getCenter()
        {
            return Position + new Vector2(Size.X / 2, Size.Y / 2);
        }

        public abstract bool checkCollision(PhysObj otherObj);

        public abstract void reactToCollision(PhysObj otherObj);

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, Color.Maroon);
        }
    }
}
