using System;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Scenes;
using MeuJogo.Content.Core;
using Vector2 = System.Numerics.Vector2;

namespace MeuJogo.Content
{
    public static class GameSettings
    {
        public static int BaseWidth = 1280;
        public static int BaseHeight = 720;
        public static Vector2 Scale = Vector2.One;
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SceneManager sceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Tela cheia
            graphics.IsFullScreen = true;
            graphics.SynchronizeWithVerticalRetrace = false; // desativa VSync
            IsFixedTimeStep = false; // FPS livre
        }

        protected override void Initialize()
        {
            // Ajusta resolução da tela
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();

            // calcula escala
            float scaleValue = Math.Min(
                (float)graphics.PreferredBackBufferWidth / GameSettings.BaseWidth,
                (float)graphics.PreferredBackBufferHeight / GameSettings.BaseHeight
            );
            GameSettings.Scale = new Vector2(scaleValue, scaleValue);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Inicializa o SceneManager
            sceneManager = new SceneManager(spriteBatch, GameSettings.Scale);

            // Cria e registra as cenas automaticamente
            SceneFactory.SetupScenes(GraphicsDevice, sceneManager);

            // Define a primeira cena como ativa
            sceneManager.SetFirstScene();

            // Opcional: ajusta a posição da Hu Tao (se existir na cena)
            var activeScene = sceneManager.GetActiveScene();
            var hutao = activeScene?.GameObjects.Find(obj => obj.GetComponent<Components.SpriteRenderer>() != null);
            if (hutao != null)
            {
                // centraliza na tela
                hutao.Transform.Position = new Vector2(GameSettings.BaseWidth / 2f, GameSettings.BaseHeight / 2f);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // Atualiza a cena ativa
            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

            // Desenha a cena ativa
            sceneManager.Draw();

            base.Draw(gameTime);
        }
    }
}