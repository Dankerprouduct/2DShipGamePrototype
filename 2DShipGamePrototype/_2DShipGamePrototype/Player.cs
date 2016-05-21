using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework; 

namespace _2DShipGamePrototype
{
    public class Player
    {

        private Texture2D sprite;
        public Vector2 velocity;

        private Vector2 position;
        private KeyboardState keyboardState;
        private MouseState mouseState;
        private float angle = 0; 
        public Player(string name, Ship ship)
        {

        }

        public void LoadContent(ContentManager content)
        {

        }
        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            Movement(); 
        }

        private void MouseMovement()
        {
            mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            Vector2 direction = mousePosition - position;
            direction.Normalize();
            angle = (float)Math.Atan2(direction.Y, direction.X); 

        }
        private void Movement()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
