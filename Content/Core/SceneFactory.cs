using Microsoft.Xna.Framework;
using MeuJogo.Content.component;
using MeuJogo.Content.Components;
using MeuJogo.Content.Core;

namespace MeuJogo.Content.Scenes
{
    public static class SceneFactory
    {
        public static void SetupScenes(Microsoft.Xna.Framework.Graphics.GraphicsDevice device, SceneManager manager)
        {
            
            //------------------------------------
            //------------- CENA 1 ---------------
            //------------------------------------
            var mainScene = new Scene(device);

            // Mario
            var player = mainScene.AddGameObject("Content/Assets/Sprites/Mario.jpg");
            player.Transform.Position = new Vector2(400, 200);
            player.Transform.Scale = new  Vector2(0.5f,  0.5f);
            

            // Quadrado
            var square = mainScene.AddGameObject("Content/Assets/Sprites/Square.png");
            square.Transform.Position = new Vector2(200, 200);
            square.Transform.Scale = new Vector2(100, 100);
            square.AddComponent(new Rigidbody());
            square.GetComponent<Rigidbody>().UseGravity = false;
            square.AddComponent(new PlayerController{Speed = 200f});
            
            //texto
            var text = mainScene.AddGameObject();
            text.AddComponent(new Text(device,"texto sem ser pro"));

            manager.AddScene("Main", mainScene);
            
            //------------------------------------
            //------------- CENA 2 ---------------
            //------------------------------------w
            var scene2 = new Scene(device);

// Player (Square 1x1)
            player = scene2.AddGameObject("Content/Assets/Sprites/Square.png");
            player.Transform.Position = new Vector2(400, 100);
            player.Transform.Scale = new Vector2(50, 50); // aumenta o 1x1 para ser visível
            var rb = player.AddComponent(new Rigidbody());
            rb.UseGravity = true;
            
            player.AddComponent(new PlayerController { Speed = 200f });

// Chão (Square 1x1)
            var ground = scene2.AddGameObject("Content/Assets/Sprites/Square.png");
            ground.Transform.Position = new Vector2(400, 500);
            ground.Transform.Scale = new Vector2(800, 50);
           

            manager.AddScene("Scene2", scene2);
        }
    }
}