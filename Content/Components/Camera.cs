// Camera só guarda dados

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Camera : Component
{
    public Vector2 Position;
    public float Zoom = 1f;
    public float Rotation = 0f;

    public Matrix GetViewMatrix()
    {
        var screenCenter = new Vector2( 683, 384);
        
        return Matrix.CreateTranslation(new Vector3(-Position + screenCenter, 0f)) *
               Matrix.CreateRotationZ(Rotation) *
               Matrix.CreateScale(Zoom, Zoom, 1f);
    }
}