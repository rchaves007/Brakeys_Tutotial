using Godot;

namespace BrakeysTutorial.scripts;

public partial class Player : CharacterBody2D {
    private const float Speed = 130.0f;
    private const float JumpVelocity = -300.0f;

    private AnimatedSprite2D _animatedSprite;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    private float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready() {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta) {
        var velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y += Gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
            velocity.Y = JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        var direction = Input.GetAxis("move_left", "move_right");

        if (IsOnFloor())
            _animatedSprite.Play(direction != 0 ? "run" : "idle");
        else
            _animatedSprite.Play("jump");

        if (direction != 0) {
            _animatedSprite.FlipH = direction < 0;
            velocity.X = direction * Speed;
        }
        else {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
