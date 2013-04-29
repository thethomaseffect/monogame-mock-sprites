#region Licence

/************************************************************************
Copyright (c) 2013 Thomas Geraghty

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
/************************************************************************/

#endregion Licence

using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;

namespace MockSpriteCreatorAPI
{
    internal class MainInterface
    {
        public static string GenerateSprite(string spriteName, int width, int height)
        {
            // Check Preconditions
            Contract.Requires(spriteName != null);
            Contract.Requires(width > 0);
            Contract.Requires(height > 0);

            //TODO: Generate filename based on parameters
            //TODO: Check if file with filename already exists

            string spriteString = string.Format("{0}\n{1}x{2}", spriteName, width, height);
            Font font = new Font("Courier", 12, FontStyle.Bold, GraphicsUnit.Point);

            int distanceFromLeft = (width / 2) - (spriteString.Length * 10 / 2);
            int distanceFromTop = (height / 2) - font.Height / 2;

            Bitmap generatedSprite = new Bitmap(width, height);
            Graphics graphicsObject = Graphics.FromImage(generatedSprite);
            graphicsObject.Clear(Color.CornflowerBlue); //TODO: Allow changing this
            graphicsObject.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphicsObject.DrawString(spriteString, font, new SolidBrush(Color.Black), distanceFromLeft, distanceFromTop);
            graphicsObject.Flush();
            string folderPath = System.IO.Directory.CreateDirectory(@"C:\Images").FullName; //TODO: Change to relative folder
            string absolutePath = folderPath + @"\test.png"; //TODO: Set name based on parameters
            generatedSprite.Save(absolutePath, ImageFormat.Png);
            return absolutePath;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Sprite created at: " + GenerateSprite("Test", 300, 300) + ".\nPress any key to exit.");
            // Keep console open in debug mode
            Console.ReadKey();
        }
    }
}