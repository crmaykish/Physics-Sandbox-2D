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
        public PhysRectangle(Texture2D texture, Vector2 position, Vector2 velocity) : base(texture, position, velocity) { }

        public override void checkCollision(PhysObj otherObj)
        {

        }

        public override void reactToCollision()
        {

        }
    }
}
