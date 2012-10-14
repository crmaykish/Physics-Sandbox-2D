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
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TextureFactory texFactory;
        Texture2D circle50;
        Texture2D tracer;

        List<PhysObj> physObjects;

        List<Vector2> ballTracer;

        #region Constants
        const int WIDTH = 1280;
        const int HEIGHT = 720;
        #endregion

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;

            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            texFactory = new TextureFactory(GraphicsDevice);

            physObjects = new List<PhysObj>();

            ballTracer = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load some Textures from the Factory
            circle50 = texFactory.GenerateCircleTexture(25);
            tracer = texFactory.GenerateSquareTexture(1);

            physObjects.Add(new PhysCircle(circle50, new Vector2(100,100), new Vector2(5.0f, 3.0f), 1.0f));
            physObjects.Add(new PhysCircle(circle50, new Vector2(600, 130), new Vector2(-1.0f, 1.0f), 1.0f));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            UpdateMouse();

            // update all objects
            foreach (PhysObj o in physObjects)
            {
                o.Update();
                //ballTracer.Add(o.Position + new Vector2(25, 25));
            }

            // collision detection
            for (int i = 0; i < physObjects.Count; i++)
            {
                for (int j = i + 1; j < physObjects.Count; j++)
                {
                    if (physObjects[i].checkCollision(physObjects[j]))
                    {
                        physObjects[i].reactToCollision(physObjects[j]);
                    }
                }
            }

            base.Update(gameTime);
        }

        MouseState state;
        MouseState lastState;

        public void UpdateMouse()
        {
            state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released)
            {
                //add a ball
                physObjects.Add(new PhysCircle(circle50, new Vector2(state.X - 25, state.Y - 25), Vector2.Zero, 1.0f));
            }

            lastState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //foreach (Vector2 v in ballTracer)
            //{
            //    spriteBatch.Draw(tracer, v, Color.Black);
            //}

            foreach (PhysObj o in physObjects)
            {
                o.Draw(spriteBatch);
            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
