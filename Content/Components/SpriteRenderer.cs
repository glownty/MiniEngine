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

        public SpriteRenderer(GraphicsDevice device, string texturePath)
        {
            Texture = Texture2D.FromFile(device, texturePath);

            Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
        }

        // Método para desenhar usando SpriteBatch
        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation = 0f, Vector2 scale = default)
        {
            if (scale == default) scale = Vector2.One;

            // Define os efeitos de flip
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
                scale,
                effects,
                0f
            );
        }
    }
}