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
    class PhysCircle : PhysObj
    {
        public int radius;

        public PhysCircle(Texture2D texture, Vector2 position, Vector2 velocity, float mass) : base(texture, position, velocity, mass)
        {
            radius = Size.X / 2;
        }

        public override bool checkCollision(PhysObj otherObj)
        {
            PhysCircle otherCircle = (PhysCircle)otherObj;

            // for other shapes, there will need to be a method that returns the point closest to this circle
            // depending on shape type, rotation, etc. with that, this function should still work

            float distance = (otherCircle.getCenter() - getCenter()).Length();

            if (distance < radius + otherCircle.radius)
            {
                return true;
            }
            return false;
        }

        public override void reactToCollision(PhysObj otherObj)
        {
            PhysCircle otherCircle = (PhysCircle)otherObj;

            Vector2 difference = getCenter() - otherCircle.getCenter();
            float d = difference.Length();

            Vector2 mtd = difference * ((radius + otherCircle.radius) - d) / d;

            float im1 = 1 / Mass;
            float im2 = 1 / otherObj.Mass;

            Position += mtd * (im1 / (im1 + im2));
            otherObj.Position -= mtd * (im2 / (im1 + im2));

            Vector2 v = Velocity - otherObj.Velocity;
            Vector2 mtdN = mtd;
            mtdN.Normalize();
            float vn = Vector2.Dot(v, mtdN);

            if (vn > 0.0f)
            {
                return;
            }

            float i = (-(1.0f + bounce) * vn) / (im1 + im2);
            Vector2 impulse = mtdN * i;

            Velocity += impulse * im1;
            otherObj.Velocity -= impulse * im2;
        }
    }
}
