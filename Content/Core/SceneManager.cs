using System.Collections.Generic;
using System.Linq;
using MeuJogo.Content.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MeuJogo.Content.Core
{
    public class SceneManager
    {
        private Dictionary<string, Scene> scenes = new();
        private Scene activeScene;
        private SpriteBatch spriteBatch;
        private Vector2 scale;

        // Construtor atualizado para receber SpriteBatch e escala
        public SceneManager(SpriteBatch spriteBatch, Vector2 scale)
        {
            this.spriteBatch = spriteBatch;
            this.scale = scale;
        }

        /// <summary>
        /// Adiciona uma nova cena ao SceneManager
        /// </summary>
        public void AddScene(string name, Scene scene)
        {
            // Configura a cena para usar o SpriteBatch e a escala
            scene.SetSpriteBatch(spriteBatch);
            scene.SetScale(scale);
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
        
        public void SetFirstScene()
        {
            if (scenes.Count > 0)
            {
                var first = scenes.Keys.First();
                SetActiveScene(first);
            }
        }

        // Retorna a cena ativa
        public Scene GetActiveScene() => activeScene;
    }
}