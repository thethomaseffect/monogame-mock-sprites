﻿#region Licence

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

using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;

namespace MockSpriteCreatorAPI
{
    internal class MainInterface
    {
        public static string GenerateSprite(Sprite sprite)
        {
            // Check Preconditions
            Contract.Requires(sprite.SpriteName != null, "Error: SpriteName cannot be null.");
            Contract.Requires(sprite.SpriteWidth > 0, "Error: SpriteWidth must be greater than 0.");
            Contract.Requires(sprite.SpriteHeight > 0, "Error: SpriteHeight must be greater than 0.");

            // Generate filename passed on parameters, replacing spaces with underscores
            string filename = "mock_" + sprite.SpriteName.Replace(" ", "_") +
                "_" + sprite.SpriteWidth + "x" + sprite.SpriteHeight + ".png";

            // Fail fast if there's a chance the filename will be too long
            Contract.Assert(filename.Length < 128, "Error: Filename too long.");

            //TODO: Check if file with filename already exists

            var spriteString = string.Format("{0}\n{1}x{2}", sprite.SpriteName,
                sprite.SpriteWidth, sprite.SpriteHeight);
            var font = new Font("Courier", 12, FontStyle.Bold, GraphicsUnit.Point);

            var distanceFromLeft = (sprite.SpriteWidth / 2) - (sprite.SpriteName.Length * 10 / 2);
            var distanceFromTop = (sprite.SpriteHeight / 2) - font.Height / 2;

            var generatedSprite = new Bitmap(sprite.SpriteWidth, sprite.SpriteHeight);
            Graphics graphicsObject = Graphics.FromImage(generatedSprite);
            graphicsObject.Clear(Color.CornflowerBlue); //TODO: Allow changing this
            graphicsObject.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphicsObject.DrawString(spriteString, font, new SolidBrush(Color.Black),
                distanceFromLeft, distanceFromTop);
            graphicsObject.Flush();
            var folderPath = System.IO.Directory.CreateDirectory(@"C:\Images").FullName; //TODO: Change to relative folder
            var absolutePath = folderPath + "\\" + filename;
            generatedSprite.Save(absolutePath, ImageFormat.Png);
            return absolutePath;
        }

        private static void Main()
        {
            Console.WriteLine("Sprite created at: " + GenerateSprite(new Sprite("Test Sprite", 300, 300)) +
                ".\nPress any key to exit.");
            // Keep console open in debug mode
            Console.ReadKey();
        }
    }
}