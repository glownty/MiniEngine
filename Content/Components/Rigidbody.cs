using MeuJogo.Content.Primitives;
using Microsoft.Xna.Framework;

namespace MeuJogo.Content.Components;

public class Rigidbody : Component
{
    public Vector2 Velocity = Vector2.Zero;
    public float Mass = 1f;
    public bool UseGravity = true;

    /// <summary>
    /// Pixels por segundo ao quadrado
    /// </summary>
    public float Gravity = 5000f;
    public float GravityScale = 1f;

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (UseGravity)
        {
            Velocity.Y += Gravity * dt;
        }

        GameObject.Transform.Position += Velocity * dt * GravityScale;
    }
}