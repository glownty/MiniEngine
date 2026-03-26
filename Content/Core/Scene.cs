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

        // Câmera ativa da cena
        protected Camera ActiveCamera { get; private set; }

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

        public SpriteBatch GetSpriteBatch() => SpriteBatch;
        public GraphicsDevice GetGraphicsDevice() => GraphicsDevice;

        // Define a escala da cena
        public void SetScale(Vector2 scale) => Scale = scale;

        public virtual void Load()
        {
            Font = BitmapFont.FromFile(GraphicsDevice, "Content/Fonts/PRO.fnt");
        }

        // Adiciona GameObject normal (com sprite opcional)
        public GameObject AddGameObject(string spritePath = null)
        {
            var obj = new GameObject();
            obj.Scene = this;

            if (!string.IsNullOrEmpty(spritePath))
            {
                var renderer = new SpriteRenderer(GraphicsDevice, spritePath);
                obj.AddComponent(renderer);
            }

            objects.Add(obj);
            return obj;
        }

        // Adiciona GameObject com câmera
        public GameObject AddGameObject(Camera camera)
        {
            var obj = new GameObject();
            obj.Scene = this;

            obj.AddComponent(camera);
            objects.Add(obj);

            // Define câmera ativa da cena
            ActiveCamera = camera;
            return obj;
        }
        
        public Camera GetCamera() => ActiveCamera;

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
            
            if (ActiveCamera != null)
                SpriteBatch.Begin(transformMatrix: ActiveCamera.GetViewMatrix());
            else
                SpriteBatch.Begin();

            Renderer.Scale = Scale;
            Renderer.DrawAll(objects);

            SpriteBatch.End();
        }
    }
}