using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Primitives;
using MeuJogo.Content.Components;

namespace MeuJogo.Content.Components
{
    public class DebugPosition : Component
    {
        private SpriteFont font;
        private Color color;

        public DebugPosition(SpriteFont font, Color color = default)
        {
            this.font = font;
            this.color = color == default ? Color.White : color;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Pega a posição do GameObject
            Vector2 pos = GameObject.Transform.Position;

            // Converte para string
            string text = $"X:{pos.X:0} Y:{pos.Y:0}";

            // Desenha na tela
            spriteBatch.DrawString(font, text, pos, color);
        }
    }
}