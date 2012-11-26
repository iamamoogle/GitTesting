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

namespace GitTesting
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;
        int floor = 340;

        GameObject megaman;
        Animation run;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            megaman = new GameObject();
            megaman.Scale = 2.0f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("stage");

            megaman.Sprite = Content.Load<Texture2D>("MegaMan");
            //HACK
            megaman.Position = new Vector2(0, floor - 40);

            run = new Animation();
            run.FrameCount = 3;
            run.Frames = new Rectangle[3];
            run.Frames[0] = new Rectangle(0, 31, 34, 30);
            run.Frames[1] = new Rectangle(34, 31, 34, 30);
            run.Frames[2] = new Rectangle(68, 31, 34, 30);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || ks.IsKeyDown(Keys.Escape))
                this.Exit();

            if (ks.IsKeyDown(Keys.Left))
            {
                megaman.Position.X -= 5;
                megaman.Facing = Direction.Left;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                megaman.Position.X += 5;
                megaman.Facing = Direction.Right;
            }

            // TODO: Add your update logic here

            run.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 1.0f);

            SpriteEffects effects = megaman.Facing == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(megaman.Sprite, megaman.Position, run.CurrentFrame, Color.White, 0.0f, Vector2.Zero, megaman.Scale, effects, 0.0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
