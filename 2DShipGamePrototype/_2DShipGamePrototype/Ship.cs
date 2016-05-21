using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input; 
namespace _2DShipGamePrototype
{
    public class Ship
    {
        private ShipGameLibrary.Ship ship;
        private Vector2 position;
        private Vector2 velocity;
        private Texture spriteSheet;
        private KeyboardState keyboardState;
        private MouseState mouseState;
        public float angle = 0f; 
        public Ship(ShipGameLibrary.Ship _ship)
        {
            ship = _ship;
            ship.height = ship.ship.GetLength(1);
            ship.width = ship.ship.GetLength(0); 
        }
        
        public void LoadContent(ContentManager content)
        {
            
        }
        public void Update()
        {
            MouseMovement();
            Movement(); 
               
        }

        private void Movement()
        {
            keyboardState = Keyboard.GetState();

        }
        private void MouseMovement()
        {
            mouseState = Mouse.GetState();
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            Vector2 direction = position - mousePosition;
            direction.Normalize();

            angle = (float)Math.Atan2(direction.X, direction.Y); 

        }
        public void Draw()
        {
            for (int x = 0; x < ship.width; x++)
            {
                for (int y = 0; y < ship.height; y++)
                {
                    for (int xX = 0; x < ship.ship[x, y].Ids.GetLength(0); xX++)
                    {
                        for (int yY = 0; yY < ship.ship[x, y].Ids.GetLength(1); yY++)
                        {
                            // ship.ship[x,y].Ids[xX,yY]
                        }
                    }
                }
            }
        }

    }
}
