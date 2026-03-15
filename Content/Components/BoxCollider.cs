using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;

public class BoxCollider : Component
{
    public Vector2 Size;
    public bool IsTrigger = false;

    public BoxCollider(float width, float height)
    {
        Size = new Vector2(width, height);
    }
    
    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(
                (int)(GameObject.Transform.Position.X - Size.X / 2),
                (int)(GameObject.Transform.Position.Y - Size.Y / 2),
                (int)Size.X,
                (int)Size.Y
            );
        }
    }
    
    public static bool IsColliding(BoxCollider a, BoxCollider b)
    {
        return a.Bounds.Intersects(b.Bounds);
    }
}