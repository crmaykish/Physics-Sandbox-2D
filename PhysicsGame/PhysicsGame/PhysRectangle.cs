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
    class PhysRectangle : PhysObj
    {
        public float Rotation;
        public float AngularVelocity;

        public PhysRectangle(Texture2D texture, Vector2 position, Vector2 velocity, float mass) : base(texture, position, velocity, mass)
        {
            Rotation = 0.0f;
            AngularVelocity = 0.06f;            
        }

        public override void Update()
        {
            base.Update();

            //Rotation += AngularVelocity;
        }

        public override void Draw(SpriteBatch sb)
        {
            Vector2 origin = new Vector2(Size.X / 2, Size.Y / 2);

            sb.Draw(Texture, Position, null, Color.MidnightBlue, Rotation, origin, 1.0f, SpriteEffects.None, 1);

        }

        public override bool checkCollision(PhysObj otherObj)
        {
            return false;
        }

        public override void reactToCollision(PhysObj otherObj)
        {
            throw new NotImplementedException();
        }

    }
}
