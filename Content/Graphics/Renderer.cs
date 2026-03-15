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

        public Renderer(GraphicsDevice device, SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        public void DrawAll(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                var sprite = obj.GetComponent<SpriteRenderer>();

                if (sprite != null)
                {
                    SpriteEffects effects = SpriteEffects.None;

                    if (sprite.FlipX)
                        effects |= SpriteEffects.FlipHorizontally;

                    if (sprite.FlipY)
                        effects |= SpriteEffects.FlipVertically;

                    SpriteBatch.Draw(
                        sprite.Texture,
                        obj.Transform.Position,
                        null,
                        sprite.Color,
                        obj.Transform.Rotation,
                        obj.GetComponent<SpriteRenderer>().Origin,
                        obj.Transform.Scale,
                        effects,
                        0f
                    );
                }
                
                var text = obj.GetComponent<Text>();

                if (text != null)
                {
                    SpriteBatch.DrawString(
                        text.Font,
                        text.Value,
                        obj.Transform.Position,
                        text.Color
                    );
                }
            }
        }
    }
}