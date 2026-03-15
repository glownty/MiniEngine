using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MeuJogo.Content.component
{
    public class PlayerController : Component
    {
        public float Speed = 200f; // pixels por segundo
        private Rigidbody rb;

        public override void Update(GameTime gameTime)
        {
            if (rb == null)
            {
                rb = GameObject.GetComponent<Rigidbody>();
                if (rb == null) return;
            }

            Vector2 movement = Vector2.Zero;
            var kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.W)) movement.Y -= 1;
            if (kb.IsKeyDown(Keys.S)) movement.Y += 1;
            if (kb.IsKeyDown(Keys.A)) movement.X -= 1;
            if (kb.IsKeyDown(Keys.D)) movement.X += 1;

            if (movement != Vector2.Zero)
            {
                movement.Normalize();
                rb.Velocity = movement * Speed;
            }
            else
            {
                rb.Velocity = Vector2.Zero;
            }
        }
    }
}