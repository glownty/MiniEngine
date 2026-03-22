using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MeuJogo.Content.Primitives;
using MeuJogo.Content.Components;
using MonoGame.Extended.BitmapFonts;

namespace MeuJogo.Content.Graphics
{
    public class Renderer
    {
        public SpriteBatch SpriteBatch { get; }
        public Vector2 Scale { get; set; } = Vector2.One; 

        public Renderer(GraphicsDevice device, SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        public void DrawAll(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                var sprite = obj.GetComponent<SpriteRenderer>();
                var text = obj.GetComponent<Text>();
                
                if (obj.GetComponent<SpriteRenderer>() != null) {
                    sprite.Draw(SpriteBatch);
                }

                if (obj.GetComponent<Text>() != null) {
                    text.Draw(SpriteBatch);
                }
            }
        }
    }
}