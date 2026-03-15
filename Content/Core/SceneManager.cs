using System.Collections.Generic;
using MeuJogo.Content.Scenes;
using Microsoft.Xna.Framework;

namespace MeuJogo.Content.Core
{
    public class SceneManager
    {
        private Dictionary<string, Scene> scenes = new();
        private Scene activeScene;

        /// <summary>
        /// Adiciona uma nova cena ao SceneManager
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scene"></param>
        public void AddScene(string name, Scene scene)
        {
            scenes[name] = scene;
        }

        // Define a cena ativa pelo nome
        public void SetActiveScene(string name)
        {
            if (scenes.ContainsKey(name))
            {
                activeScene = scenes[name];
                activeScene.Load();
            }
        }

        // Atualiza a cena ativa
        public void Update(GameTime gameTime)
        {
            activeScene?.Update(gameTime);
        }

        // Desenha a cena ativa
        public void Draw()
        {
            activeScene?.Draw();
        }

        // Retorna a cena ativa
        public Scene GetActiveScene() => activeScene;
    }
}