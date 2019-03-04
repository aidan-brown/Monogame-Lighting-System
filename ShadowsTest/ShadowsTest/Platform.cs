﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ShadowsTest
{
    class Platform
    {
        Rectangle rect, shadowRect;
        Texture2D texture;
        float lightRot;

        Vector2 pNW, pNE, pSW, pSE;

        public Vector2 PointNW
        {
            get { return pNW; }
        }
        public Vector2 PointNE
        {
            get { return pNE; }
        }
        public Vector2 PointSW
        {
            get { return pSW; }
        }
        public Vector2 PointSE
        {
            get { return pSE; }
        }
        private Vector2 MidPoint
        {
            get { return new Vector2(rect.X + rect.Width / 2, rect.Y + rect.Height / 2); }
        }

        public bool isInLight;

        public Platform(Rectangle r, Texture2D t)
        {
            rect = r;
            texture = t;

            pNW = new Vector2(r.X, r.Y);
            pNE = new Vector2(r.X + r.Width, r.Y);
            pSW = new Vector2(r.X, r.Y + r.Height);
            pSE = new Vector2(r.X + r.Width, r.Y + r.Height);
        }

        public void Update(float _lightRot)
        {
            if (isInLight)
            {
                shadowRect = new Rectangle((int)MidPoint.X, (int)MidPoint.Y, rect.Width * 4, (int)Math.Sqrt(Math.Pow(rect.Width, 2) + Math.Pow(rect.Height, 2)));
                lightRot = _lightRot;
            }
        }

        public void Draw(SpriteBatch sb)
        { 
            if(isInLight)
            {
                sb.Draw(texture, destinationRectangle: shadowRect, color: Color.Black, rotation: lightRot, origin: new Vector2(0, texture.Height/2));
            }
            sb.Draw(texture, rect, Color.White);
        }
    }
}
