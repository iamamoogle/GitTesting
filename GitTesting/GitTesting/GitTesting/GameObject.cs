using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GitTesting
{
    enum Direction { Right, Left };

    class GameObject
    {
        private Texture2D mSprite;
        public Texture2D Sprite
        {
            get { return mSprite; }
            set { mSprite = value; }
        }

        public Vector2 Position;
        
        private float mScale;
        public float Scale
        {
            get { return mScale; }
            set { mScale = value; }
        }

        public Vector2 Velocity;

        public Direction Facing;

        public GameObject()
        {
            mSprite = null;
            Position = Vector2.Zero;
            mScale = 1.0f;
            Velocity = Vector2.Zero;
            Facing = Direction.Right;
        }
    }
}
