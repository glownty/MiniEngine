using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Core;

namespace MeuJogo.Content
{
    public static class GameSettings
    {
        public static int BaseWidth = 1280;
        public static int BaseHeight = 720;

        // escala calculada com base na tela atual
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
            // aplica resolução da tela cheia
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();

            // calcula escala para os objetos
            GameSettings.Scale = Math.Min(
                (float)graphics.PreferredBackBufferWidth / GameSettings.BaseWidth,
                (float)graphics.PreferredBackBufferHeight / GameSettings.BaseHeight
            ) * Vector2.One;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sceneManager = new SceneManager(spriteBatch, GameSettings.Scale);
            SceneFactory.SetupScenes(GraphicsDevice, sceneManager);
            sceneManager.SetFirstScene();
        }

        protected override void Update(GameTime gameTime)
        {
            sceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            sceneManager.Draw(); // agora a SceneManager deve usar a escala
            base.Draw(gameTime);
        }
    }
}