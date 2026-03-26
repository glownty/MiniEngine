using System;
using MeuJogo.Content.Primitives;
using Microsoft.Xna.Framework;

public class CameraController : Component
{
    private Camera _camera;
    private GameObject _target;

    // Proporção da deadzone em relação à tela (0..1)
    public float DeadZoneProportion = 0.25f; // 25% tanto horizontal quanto vertical
    public float LerpSpeed = 5f;

    public CameraController(Camera camera, GameObject target)
    {
        _camera = camera;
        _target = target;
    }

    public override void Update(GameTime gameTime)
    {
        if (_camera == null || _target == null)
            return;

        Vector2 targetPos = _target.Transform.Position;
        Vector2 camPos = _camera.Position;

        // --- deadzone quadrada ---
        Vector2 viewport = new Vector2(1366f, 768f);
        Vector2 deadZone = new Vector2(
            viewport.X * DeadZoneProportion,
            viewport.X * DeadZoneProportion // usa X também pra deixar quadrado
        );

        // diferença entre player e câmera
        Vector2 diff = targetPos - camPos;
        Vector2 move = Vector2.Zero;

        // move só se player sair da deadzone
        if (Math.Abs(diff.X) > deadZone.X / 2)
            move.X = diff.X - Math.Sign(diff.X) * deadZone.X / 2;

        if (Math.Abs(diff.Y) > deadZone.Y / 2)
            move.Y = diff.Y - Math.Sign(diff.Y) * deadZone.Y / 2;

        // suavidade / delay
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _camera.Position += move * LerpSpeed * dt;
    }
}