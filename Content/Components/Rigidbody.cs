using Microsoft.Xna.Framework;
using MeuJogo.Content.Primitives;

namespace MeuJogo.Content.Components
{
    public class Rigidbody : Component
    {
        public Vector2 Velocity = Vector2.Zero;

        public float Mass = 1f;

        public bool UseGravity = true;

        public float Gravity = 5000f;

        public float GravityScale = 1f;

        public bool IsGrounded = false;

        private BoxCollider _collider;

        public override void Update(GameTime gameTime)
        {
            if (_collider == null)
                _collider = GameObject.GetComponent<BoxCollider>();

            if (_collider == null)
                return;

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (UseGravity)
                Velocity.Y += Gravity * GravityScale * dt;

            Vector2 position = GameObject.Transform.Position;

            // ---------------- MOVIMENTO X ----------------
            position.X += Velocity.X * dt;
            GameObject.Transform.Position = position;

            foreach (var obj in GameObject.Scene.GameObjects)
            {
                if (obj == GameObject) continue;

                var other = obj.GetComponent<BoxCollider>();
                if (other == null) continue;

                if (BoxCollider.IsColliding(_collider, other))
                {
                    position.X -= Velocity.X * dt;
                    Velocity.X = 0;
                    GameObject.Transform.Position = position;
                }
            }

            // ---------------- MOVIMENTO Y ----------------
            position.Y += Velocity.Y * dt;
            GameObject.Transform.Position = position;

            IsGrounded = false;

            foreach (var obj in GameObject.Scene.GameObjects)
            {
                if (obj == GameObject) continue;

                var other = obj.GetComponent<BoxCollider>();
                if (other == null) continue;

                if (BoxCollider.IsColliding(_collider, other))
                {
                    position.Y -= Velocity.Y * dt;

                    if (Velocity.Y > 0)
                        IsGrounded = true;

                    Velocity.Y = 0;
                    GameObject.Transform.Position = position;
                }
            }

            this.Velocity.X = 1000f;
        }
        
        public void AddForce(Vector2 force)
        {
            Velocity += force / Mass;
        }
    }
}