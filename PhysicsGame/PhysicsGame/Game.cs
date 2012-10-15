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
        Texture2D circle10;
        Texture2D circle50;
        Texture2D circle100;
        Texture2D circle250;
        Texture2D rect100;
        Texture2D tracer;
        Texture2D ground;

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
            circle10 = texFactory.GenerateCircleTexture(5);
            circle50 = texFactory.GenerateCircleTexture(25);
            //circle100 = texFactory.GenerateCircleTexture(50);
            circle100 = Content.Load<Texture2D>("circle100");
            circle250 = texFactory.GenerateCircleTexture(125);
            rect100 = texFactory.GenerateRectangleTexture(60, 100);

            tracer = texFactory.GenerateSquareTexture(1);
            ground = Content.Load<Texture2D>("ground");

            //physObjects.Add(new PhysRectangle(rect100, new Vector2(100, 100), new Vector2(0.0f, 0.0f), 1.5f));
            physObjects.Add(new PhysCircle(circle100, new Vector2(100, 100), new Vector2(30.0f, 3.0f), 1.0f));
            physObjects.Add(new PhysCircle(circle100, new Vector2(600, 130), new Vector2(-8.0f, 1.0f), 1.0f));
            physObjects.Add(new PhysCircle(circle100, new Vector2(1000, 80), new Vector2(-8.0f, 13.0f), 1.0f));
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
                //ballTracer.Add(o.getCenter());
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
                physObjects.Add(new PhysCircle(circle100, new Vector2(state.X - 50, state.Y - 50), Vector2.Zero, 1.0f));
            }

            lastState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(109, 177, 205));

            spriteBatch.Begin();

            for (int i = 0; i < WIDTH / 1024 + 1; i++)
            {
                spriteBatch.Draw(ground, new Vector2(i * 1024, HEIGHT - 100), Color.White);
            }

            foreach (Vector2 v in ballTracer)
            {
                spriteBatch.Draw(tracer, v, Color.Black);
            }

            foreach (PhysObj o in physObjects)
            {
                o.Draw(spriteBatch);
            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
