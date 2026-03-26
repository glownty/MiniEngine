using MeuJogo.Content.component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Components;

namespace MeuJogo.Content.Scenes
{
    public class MainScene : Scene
    {
        public MainScene(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Load()
        {
            var hutao = AddGameObject("Content/Assets/Sprites/hutao.png");
            hutao.Transform.Scale = Vector2.One * 0.1f;
            hutao.AddComponent(new Rigidbody(){UseGravity = false});
            hutao.AddComponent(new PlayerController());
            hutao.AddComponent(new BoxCollider( 250, 250));
            
            var yuzuha = AddGameObject("Content/Assets/Sprites/yuzuha.jpg");
            yuzuha.Transform.Scale = Vector2.One * 0.15f;
            yuzuha.Transform.Position = new  Vector2(400, 300);
            yuzuha.AddComponent(new BoxCollider(110, 180));

            var cameraGO = AddGameObject(new Camera());
            cameraGO.AddComponent(new CameraController(cameraGO.GetComponent<Camera>(), hutao));

            base.Load();
            
        }

    }
}