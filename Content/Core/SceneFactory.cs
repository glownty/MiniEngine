using MeuJogo.Content.component;
using Microsoft.Xna.Framework;
using MeuJogo.Content.Components;
using MeuJogo.Content.Scenes;
using MonoGame.Extended;

namespace MeuJogo.Content.Core
{
    public static class SceneFactory
    {
        public static void SetupScenes(
            Microsoft.Xna.Framework.Graphics.GraphicsDevice device,
            SceneManager manager)
        {

            var mainScene = new Scene(device);

            // PLAYER
            var player = mainScene.AddGameObject("Content/Assets/Sprites/Square.png");
            player.Transform.Position = new Vector2(400, 200);
            player.Transform.Scale = new Vector2(50, 50);

            player.AddComponent(new Rigidbody());
            player.AddComponent(new PlayerController ());
            player.AddComponent(new BoxCollider(50, 50));
            
            player.GetComponent<SpriteRenderer>().Color = Color.Blue;


            // CHÃO
            var ground = mainScene.AddGameObject("Content/Assets/Sprites/Square.png");
            ground.Transform.Position = new Vector2(400, 500);
            ground.Transform.Scale = new Vector2(800, 50);
            ground.AddComponent(new BoxCollider(800, 50));


            // PAREDE ESQUERDA
            var wall = mainScene.AddGameObject("Content/Assets/Sprites/Square.png");
            wall.Transform.Position = new Vector2(0, 300);
            wall.Transform.Scale = new Vector2(50, 600);
            wall.AddComponent(new BoxCollider(50, 600));


            // OBSTÁCULO PARA PULAR
            var obstacle = mainScene.AddGameObject("Content/Assets/Sprites/Square.png");
            obstacle.Transform.Position = new Vector2(500, 450);
            obstacle.Transform.Scale = new Vector2(120, 50);
            obstacle.AddComponent(new BoxCollider(120, 50));


            manager.AddScene("Main", mainScene);
        }
    }
}