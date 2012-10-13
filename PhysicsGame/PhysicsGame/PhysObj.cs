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
    class PhysObj
    {
        #region Physics Constants
        float gravity = 0.3f;
        float hFriction = -0.04f;
        float elasticity = 0.6f;
        #endregion

        Vector2 Position;
        Vector2 Velocity;
        Vector2 Mass;
    }
}
