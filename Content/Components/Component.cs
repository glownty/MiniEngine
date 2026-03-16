using MeuJogo.Content.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Component
{
    public GameObject GameObject { get; set; }

    public virtual void Start()
    {
    }

    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
    }
}