using MeuJogo.Content.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MeuJogo.Content.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Texture { get; private set; }
        public Color Color { get; set; } = Color.White;

        // Origem usada para rotação, escala e posicionamento
        public Vector2 Origin { get; private set; }

        public bool FlipX { get; set; } = false;
        public bool FlipY { get; set; } = false;

        // Escala local do sprite
        public Vector2 Scale { get; set; } = Vector2.One;
        public float Size { get; set; } = 1f;

        public SpriteRenderer(GraphicsDevice device, string texturePath)
        {
            Texture = Texture2D.FromFile(device, texturePath);

            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
        }

        // Método helper para desenhar este sprite
        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation = 0f)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (FlipX) effects |= SpriteEffects.FlipHorizontally;
            if (FlipY) effects |= SpriteEffects.FlipVertically;

            spriteBatch.Draw(
                Texture,
                position,
                null,
                Color,
                rotation,
                Origin,
                Scale * Size,
                effects,
                0f
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (FlipX) effects |= SpriteEffects.FlipHorizontally;
            if (FlipY) effects |= SpriteEffects.FlipVertically;

            spriteBatch.Draw(
                Texture,
                GameObject.Transform.Position,
                null,
                Color,
                0f,
                Origin,
                Scale * Size,
                effects,
                0f
            );
        }
    }
}