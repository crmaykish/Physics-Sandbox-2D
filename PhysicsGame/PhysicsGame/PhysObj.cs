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
        float gravity = 0.6f;
        #endregion

        Texture2D Texture;

        public Vector2 Position;
        public Vector2 Velocity;

        public PhysObj(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
        }

        public void Update()
        {
            Velocity.Y += gravity;
            Position += Velocity;
        }

        public abstract void checkCollision(PhysObj otherObj);

        public abstract void reactToCollision();

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, Color.White);
        }
    }
}
