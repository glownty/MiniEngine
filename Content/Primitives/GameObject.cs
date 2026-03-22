using System.Collections.Generic;
using MeuJogo.Content.component;
using Microsoft.Xna.Framework;
using MeuJogo.Content.Components;
using MeuJogo.Content.Scenes;
using Microsoft.Xna.Framework.Graphics;

namespace MeuJogo.Content.Primitives
{
    public class GameObject
    {
        public Transform Transform { get; set; }

        public Scene Scene { get; set; }

        protected List<Component> components = new();

        public GameObject()
        {
            Transform = new Transform();
        }

        public T AddComponent<T>(T component) where T : Component
        {
            component.GameObject = this;
            components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (var component in components)
            {
                if (component is T t)
                    return t;
            }

            return null;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }
    }
}