using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using MeuJogo.Content.Scenes;

namespace MeuJogo.Content.Core
{
    public class SceneFactory
    {
        public static void SetupScenes(GraphicsDevice device, SceneManager manager)
        {
            var sceneType = typeof(Scene);

            var scenes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(sceneType));

            foreach (var type in scenes)
            {
                var scene = (Scene)Activator.CreateInstance(type, device);
                
                var sceneName = type.Name.Replace("Scene", "");

                manager.AddScene(sceneName, scene);
            }
        }
    }
}