using Godot;

namespace BrakeysTutorial.scripts;

public partial class Slime : Node2D {
    private const float Speed = 60.0f;

    private AnimatedSprite2D _animatedSprite;
    private int _direction = 1;
    private RayCast2D _rayCastLeft;
    private RayCast2D _rayCastRight;

    public override void _Ready() {
        _rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
        _rayCastRight = GetNode<RayCast2D>("RayCastRight");
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (_rayCastRight.IsColliding()) {
            _animatedSprite.FlipH = true;
            _direction = -1;
        }

        if (_rayCastLeft.IsColliding()) {
            _animatedSprite.FlipH = false;
            _direction = 1;
        }

        var position = Position;
        position.X += _direction * Speed * (float)delta;

        Position = position;
    }
}
