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
        protected SpriteBatch SpriteBatch { get; }
        protected Renderer Renderer { get; }

        protected List<GameObject> objects = new();

        public List<GameObject> GameObjects => objects;

        protected BitmapFont Font { get; private set; }

        public Scene(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Renderer = new Renderer(GraphicsDevice, SpriteBatch);
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
                obj.AddComponent(new SpriteRenderer(GraphicsDevice, spritePath));
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
            SpriteBatch.Begin();
            Renderer.DrawAll(objects);
            SpriteBatch.End();
        }
    }
}