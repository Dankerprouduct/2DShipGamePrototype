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

namespace _2DShipGamePrototype
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState;

        Ship ship; 
        public TextureManager textureManager; 
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; 
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureManager = new TextureManager(Content);

            ship = new Ship(new ShipGameLibrary.Ship(), this);
            ship.LoadContent(Content); 
        }


        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            // Allows the game to exit
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit(); 
            }
            


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            ship.Draw(spriteBatch); 
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
