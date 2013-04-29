#region Licence

// Copyright (c) 2013 Thomas Geraghty
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion Licence

namespace MockSpriteCreatorAPI
{
    /// <summary>
    ///     A container for a sprite's properties. Since there are many different
    ///     configurations available it is recommended to use a builder for this class.
    /// </summary>
    internal class Sprite
    {
        public Sprite(string spriteName, int spriteHeight, int spriteWidth)
        {
            SpriteName = spriteName;
            SpriteHeight = spriteHeight;
            SpriteWidth = spriteWidth;
        }

        public int SpriteHeight { get; private set; }

        public string SpriteName { get; private set; }

        public int SpriteWidth { get; private set; }
    }
}