using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.IO; 
namespace _2DShipGamePrototype
{
    public class Ship
    {
        private ShipGameLibrary.Ship ship;
        private Vector2 position;
        private Vector2 velocity;
        private Texture2D spriteSheet;
        private KeyboardState keyboardState;
        private MouseState mouseState;
        private Game1 game; 
        public float angle = 0f; 

        public struct width_height
        {
            public int width;
            public int height; 
        }
        width_height[,] wdData; 

        public Ship(ShipGameLibrary.Ship _ship, Game1 gme)
        {
            game = gme; 
            ship = _ship;
            
            
            
        }
        
        public void LoadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("spritesheet");

            ship.ship = new ShipGameLibrary.Module[3, 3]; 

            ship.ship[0, 0] = new ShipGameLibrary.Module();
            ship.ship[0, 0].Name = "Blank";
            ship.ship[0, 0].type = 0;
            ship.ship[0, 0].Ids = LoadModule("Blank");

            ship.ship[0, 1] = new ShipGameLibrary.Module();
            ship.ship[0, 1].Name = "Blank";
            ship.ship[0, 1].type = 1;
            ship.ship[0, 1].Ids = LoadModule("Blank");

            ship.ship[0, 2] = new ShipGameLibrary.Module();
            ship.ship[0, 2].Name = "Engine Room";
            ship.ship[0, 2].type = 2;
            ship.ship[0, 2].Ids = LoadModule("EngineRoom 2");

            ship.ship[1, 0] = new ShipGameLibrary.Module();
            ship.ship[1, 0].Name = "Bridge";
            ship.ship[1, 0].type = 3;
            ship.ship[1, 0].Ids = LoadModule("Module1");

            ship.ship[1, 1] = new ShipGameLibrary.Module(); 
            ship.ship[1, 1].Name = "Hallway";
            ship.ship[1, 1].type = 4;
            ship.ship[1, 1].Ids = LoadModule("Hallway1");

            ship.ship[1, 2] = new ShipGameLibrary.Module();
            ship.ship[1, 2].Name = "Back Room";
            ship.ship[1, 2].type = 5;
            ship.ship[1, 2].Ids = LoadModule("Module2");

            ship.ship[2, 0] = new ShipGameLibrary.Module();
            ship.ship[2, 0].Name = "Blank";
            ship.ship[2, 0].type = 6;
            ship.ship[2, 0].Ids = LoadModule("Blank");

            ship.ship[2, 1] = new ShipGameLibrary.Module();
            ship.ship[2, 1].Name = "Blank";
            ship.ship[2, 1].type = 7;
            ship.ship[2, 1].Ids = LoadModule("Blank");

            ship.ship[2, 2] = new ShipGameLibrary.Module();
            ship.ship[2, 2].Name = "Engine Room";
            ship.ship[2, 2].type = 8;
            ship.ship[2, 2].Ids = LoadModule("EngineRoom 2");


            ship.height = ship.ship.GetLength(1);
            ship.width = ship.ship.GetLength(0);

            wdData = new width_height[3, 3];

            if (ship.height > 3)
            {
                Console.WriteLine("ERROR");

            }
            if (ship.width > 3)
            {
                Console.WriteLine("ERROR");
            }

            int width = 0;
            int height = 0; 
            for(int x  = 0; x < wdData.GetLength(0) ; x++)
            {
                for(int y = 0; y < wdData.GetLength(1); y++)
                {
                    wdData[x, y].width = ship.ship[x, y].Ids.GetLength(0);
                    wdData[x, y].height = ship.ship[x, y].Ids.GetLength(1); 

                    if(wdData[x, y].width > width)
                    {
                        width = wdData[x, y].width;
                        wdData[x, y].width = width; 
                    }
                    if(wdData[x, y].height > height)
                    {
                        height = wdData[x, y].height;
                        wdData[x, y].height = height; 
                    }
                    
                }
            }



        }

        private int[,] LoadModule(string name)
        {
            int[,] module; 

            string path = "Modules/" + name + ".txt";
            int width = 0;
            int height = File.ReadLines(path).Count();

            StreamReader sReader = new StreamReader(path);
            string line = sReader.ReadLine();
            string[] tileNo = line.Split(',');

            width = tileNo.Count();

            module = new int[width, height];
            sReader.Close();

            sReader = new StreamReader(path); 
            
            for(int x = 0; x < height; x++)
            {
                line = sReader.ReadLine();
                tileNo = line.Split(','); 

                for(int y = 0; y < width; y++)
                {
                    module[y, x] = Convert.ToInt32(tileNo[y]); 
                }
            }

            sReader.Close();
            return module; 

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
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < ship.width; x++)
            {
                for (int y = 0; y < ship.height; y++)
                {
                    for (int xX = 0; xX < ship.ship[x,y].Ids.GetLength(0); xX++)
                    {
                        for (int yY = 0; yY < ship.ship[x, y].Ids.GetLength(1); yY++)
                        {
                            
                            
                            switch (x)
                            {
                                case 0:
                                    {
                                        spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X + (xX * 32), (int)position.Y + (yY * 32) , 32, 32), game.textureManager.GetSource(ship.ship[x, y].Ids[xX, yY]), Color.White);
                                        break;
                                    }
                                case 1:
                                    {
                                        spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X + (xX * 32) + (32 * wdData[x, y].width), (int)position.Y + (yY * 32) + (32 * wdData[x, y].height), 32, 32), game.textureManager.GetSource(ship.ship[x, y].Ids[xX, yY]), Color.White);
                                        break; 
                                    }
                                case 2:
                                    {
                                        spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X + (xX * 32) + (32 * wdData[x, y].width), (int)position.Y + (yY * 32) + (32 * wdData[x, y].height), 32, 32), game.textureManager.GetSource(ship.ship[x, y].Ids[xX, yY]), Color.White);
                                        break; 
                                    }
                            }
                        }
                    }
                }
            }
        }

    }
}
