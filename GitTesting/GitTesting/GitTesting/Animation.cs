using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace GitTesting
{
    class Animation
    {
        public Rectangle[] Frames;
        public Rectangle CurrentFrame
        {
            get{ return Frames[frameNumber]; }
        }
        private int frameNumber;
        public int FrameCount;
        private float timer;
        public float FrameLength;

        public Animation()
        {
            Frames = null;
            frameNumber = 0;
            FrameCount = 0;
            timer = 0.0f;
            FrameLength = 0.15f;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > FrameLength)
            {
                frameNumber = (frameNumber + 1) % FrameCount;
                timer = 0.0f;
            }
        }
    }
}
