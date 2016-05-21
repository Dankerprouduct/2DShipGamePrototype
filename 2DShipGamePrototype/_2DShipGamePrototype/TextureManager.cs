using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.IO; 

namespace _2DShipGamePrototype
{
    public class TextureManager
    {

        public struct TextureSource
        {
            public int id;
            public Rectangle source; 
        }
        public TextureSource[] sources;
        ShipGameLibrary.Tile[] tiles;
        public TextureManager(ContentManager content)
        {

            Console.WriteLine("Loading Textures"); 
            tiles = content.Load<ShipGameLibrary.Tile[]>("Xml/Tile");

            sources = new TextureSource[tiles.Length]; 

            for(int i = 0; i < sources.Length; i++)
            {
                sources[i] = new TextureSource();
                sources[i].id = tiles[i].id;
                sources[i].source = SourceRect(tiles[i].id, "spritesheet", content);
                Console.WriteLine(sources[i].id + " " + sources[i].source); 
            }
        }
        private Rectangle SourceRect(int id,string name, ContentManager content)
        {
            string path = "TileData/" + name + ".txt";
            StreamReader streamReader = new StreamReader(path);

            int curId = 0; 
            for(int i = 0; i < tiles.Length; i++)
            {
                if(tiles[i].id == id)
                {
                    curId = i; 
                }
            }
            int height = File.ReadLines(path).Count();

            char[] splits = { '=', ' ' };

            for(int y = 0; y < height; y++)
            {
                string line = streamReader.ReadLine();
                string[] rectData = line.Split(splits); 

                foreach(string s in rectData)
                {
                    for(int i = 0; i < tiles.Length; i++)
                    {
                        if(tiles[curId].name == s)
                        {
                            streamReader.Close();
                            return new Rectangle(Convert.ToInt32(rectData[3]), Convert.ToInt32(rectData[4]), Convert.ToInt32(rectData[5]), Convert.ToInt32(rectData[6])); 
                        }
                    }

                }

                
            }
            return Rectangle.Empty;
        }

        public Rectangle GetSource(int id)
        {
            for(int i = 0; i < sources.Length; i++)
            {
                if(sources[i].id == id)
                {
                    return sources[i].source; 
                }
            }
            return Rectangle.Empty; 
        }

        
    }
}
