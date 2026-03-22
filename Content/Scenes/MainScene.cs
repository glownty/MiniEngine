using MeuJogo.Content.Components;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Scenes;
using MonoGame.Extended.Particles;

namespace MeuJogo.Content.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Load()
        {
            base.Load();
            
            var player = AddGameObject("Content/Assets/Sprites/hutao.png");
            player.GetComponent<SpriteRenderer>().Size = 0.4f;
        }
        
    }
}