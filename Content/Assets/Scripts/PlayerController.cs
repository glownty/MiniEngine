using MeuJogo.Content.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MeuJogo.Content.component
{
    public class PlayerController : Component
    {
        public float Speed = 8121200f;
        public float JumpForce = 1500f;

        private Rigidbody rb;

        public override void Update(GameTime gameTime)
        {
            if (rb == null)
            {
                rb = GameObject.GetComponent<Rigidbody>();
                if (rb == null) return;
            }

            var kb = Keyboard.GetState();

            float moveX = 0;

            if (kb.IsKeyDown(Keys.A)) moveX = -1;
            if (kb.IsKeyDown(Keys.D)) moveX = 1;

            rb.Velocity.X = moveX * Speed;

            // pulo
            if (kb.IsKeyDown(Keys.Space) && rb.IsGrounded)
            {
                rb.AddForce(new Vector2(0, -JumpForce));
            }
        }
    }
}