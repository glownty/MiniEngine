using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;
using MeuJogo.Content.Scenes;
using System;

namespace MeuJogo.Content.Core
{
    public static class SceneFactory
    {
        public static void SetupScenes(
            Microsoft.Xna.Framework.Graphics.GraphicsDevice device,
            SceneManager manager)
        {
            var mainScene = new Scene(device);

            // --- Criar X Hutao GameObjects em posições aleatórias ---
            int X = 5; // número de Hutao objects
            Random rand = new Random();

            for (int i = 0; i < X; i++)
            {
                var hutao = mainScene.AddGameObject("Content/Assets/Sprites/hutao.png");

                // Posição aleatória dentro da tela
                hutao.Transform.Position = new Vector2(
                    rand.Next(50, 1366), // assume baseWidth ~1280
                    rand.Next(50, 768)   // assume baseHeight ~720
                );

                // Escala pequena
                hutao.Transform.Scale = new Vector2(.25f, .25f);

                // Cor aleatória
                hutao.GetComponent<SpriteRenderer>().Color = new Color(
                    (float)rand.NextDouble(),
                    (float)rand.NextDouble(),
                    (float)rand.NextDouble()
                );
            }

            manager.AddScene("Main", mainScene);
        }
    }
}