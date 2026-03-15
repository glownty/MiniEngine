using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Scenes;
using MeuJogo.Content.component;
using MeuJogo.Content.Core;

namespace MeuJogo.Content
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SceneManager sceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            sceneManager = new SceneManager();
            
            SceneFactory.SetupScenes(GraphicsDevice, sceneManager);
            
            sceneManager.SetActiveScene("Main");
        }

        protected override void Update(GameTime gameTime)
        {
            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            sceneManager.Draw();

            base.Draw(gameTime);
        }
    }
}