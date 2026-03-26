using MeuJogo.Content.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MeuJogo.Content.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Texture { get; private set; }
        public Color Color { get; set; } = Color.White;
        public Vector2 Origin { get; private set; }
        public bool FlipX { get; set; } = false;
        public bool FlipY { get; set; } = false;
        public float Size { get; set; } = 1f;

        public Rectangle? SourceRectangle { get; set; } = null;

        public SpriteRenderer(GraphicsDevice device, string texturePath)
        {
            try
            {
                Texture = Texture2D.FromFile(device, texturePath);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao carregar textura: {texturePath}\n{e.Message}");
            }

            if (Texture == null)
                throw new Exception($"Texture NULL: {texturePath}");

            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation = 0f)
        {
            if (Texture == null)
                return; // evita crash

            SpriteEffects effects = SpriteEffects.None;
            if (FlipX) effects |= SpriteEffects.FlipHorizontally;
            if (FlipY) effects |= SpriteEffects.FlipVertically;

            spriteBatch.Draw(
                Texture,
                position,
                SourceRectangle,
                Color,
                rotation,
                Origin,
                GameObject.Transform.Scale * Size,
                effects,
                0f
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, GameObject.Transform.Position, GameObject.Transform.Rotation);
        }
    }
}