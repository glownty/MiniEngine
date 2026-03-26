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
        public BodyType Type;
        
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
            ResolveCollisions(ref position, false, dt);

            // ---------------- MOVIMENTO Y ----------------
            position.Y += Velocity.Y * dt;
            GameObject.Transform.Position = position;
            IsGrounded = false;
            ResolveCollisions(ref position, true, dt);
        }

        private void ResolveCollisions(ref Vector2 position, bool isYAxis, float dt)
        {
            foreach (var obj in GameObject.Scene.GameObjects)
            {
                if (obj == GameObject) continue;

                var other = obj.GetComponent<BoxCollider>();
                if (other == null) continue;

                if (other.IsTrigger || _collider.IsTrigger)
                    continue;

                if (BoxCollider.IsColliding(_collider, other))
                {
                    if (isYAxis)
                    {
                        position.Y -= Velocity.Y * dt;

                        if (Velocity.Y > 0)
                            IsGrounded = true;

                        Velocity.Y = 0;
                    }
                    else
                    {
                        position.X -= Velocity.X * dt;
                        Velocity.X = 0;
                    }

                    GameObject.Transform.Position = position;
                }
            }
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force / Mass;
        }
        
        public enum BodyType
        {
            Static,
            Dynamic,
            Kinematic,
        }
    }
}