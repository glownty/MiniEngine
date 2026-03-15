using Microsoft.Xna.Framework;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework.Graphics;

namespace MeuJogo.Content.Components
{
    public class Text : Component
    {
        public BitmapFont Font { get; set; }
        public string Value { get; set; }
        public Color Color { get; set; } = Color.White;

        private const string DefaultFontPath = "Content/Fonts/PRO.fnt";

        // Construtor completo
        public Text(BitmapFont font, string value)
        {
            Font = font;
            Value = value;
        }

        // Construtor só com string, usa fonte padrão
        public Text(GraphicsDevice device, string value)
        {
            Font = BitmapFont.FromFile(device, DefaultFontPath);
            Value = value;
        }
    }
}