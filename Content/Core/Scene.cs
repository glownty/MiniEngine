using System.Collections.Generic;
using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Primitives;
using MeuJogo.Content.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace MeuJogo.Content.Scenes
{
    public class Scene
    {
        protected GraphicsDevice GraphicsDevice { get; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected Renderer Renderer { get; private set; }

        protected List<GameObject> objects = new();
        public List<GameObject> GameObjects => objects;

        protected BitmapFont Font { get; private set; }

        // Escala aplicada na cena
        protected Vector2 Scale { get; private set; } = Vector2.One;

        public Scene(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        // Recebe o SpriteBatch do SceneManager
        public void SetSpriteBatch(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            Renderer = new Renderer(GraphicsDevice, SpriteBatch);
        }

        public SpriteBatch GetSpriteBatch()
        {
            return SpriteBatch;
        }

        public GraphicsDevice GetGraphicsDevice()
        {
            return GraphicsDevice;
        }

        // Define a escala da cena
        public void SetScale(Vector2 scale)
        {
            Scale = scale;
        }

        public virtual void Load()
        {
            Font = BitmapFont.FromFile(GraphicsDevice, "Content/Fonts/PRO.fnt");
        }

        public GameObject AddGameObject(string spritePath = null)
        {
            var obj = new GameObject();
            obj.Scene = this;

            if (!string.IsNullOrEmpty(spritePath))
            {
                var renderer = new SpriteRenderer(GraphicsDevice, spritePath);
                renderer.Scale = Scale; // aplica escala diretamente no renderer
                obj.AddComponent(renderer);
            }

            objects.Add(obj);
            return obj;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var obj in objects)
            {
                obj.Update(gameTime);
            }
        }

        public virtual void Draw()
        {
            if (SpriteBatch == null)
                return;

            SpriteBatch.Begin();

            // aplica escala para todos os objetos via Renderer
            Renderer.Scale = Scale;
            Renderer.DrawAll(objects);

            SpriteBatch.End();
        }
    }
}