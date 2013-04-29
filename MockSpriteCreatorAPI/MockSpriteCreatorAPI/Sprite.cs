using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockSpriteCreatorAPI
{
    /// <summary>
    /// A container for a sprite's properties. Since there are many different
    /// configurations available it is recommended to use a builder for this class.
    /// </summary>
    internal class Sprite
    {
        public Sprite(string SpriteName, int SpriteHeight, int SpriteWidth)
        {
            this.SpriteName = SpriteName;
            this.SpriteHeight = SpriteHeight;
            this.SpriteWidth = SpriteWidth;
        }

        public int SpriteHeight { get; set; }

        public string SpriteName { get; set; }

        public int SpriteWidth { get; set; }
    }
}