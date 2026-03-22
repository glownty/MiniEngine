using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;

namespace MeuJogo.Content.component;

public class Transform : Component
{
    public Vector2 Position { get; set; } = new Vector2(683, 384);
    public float Rotation { get; set; } = 0f;
    public Vector2 Scale { get; set; } = Vector2.One;
}