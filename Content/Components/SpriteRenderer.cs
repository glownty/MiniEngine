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
        
    }
}