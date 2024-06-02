using Godot;

namespace BrakeysTutorial.scripts;

public partial class KillZone : Area2D {
    private Timer _timer;

    public override void _Ready() {
        _timer = GetNode<Timer>("Timer");
    }

    private void OnBodyEntered(Node2D body) {
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();

        Engine.TimeScale = 0.5;
        _timer.Start();
    }

    private void OnTimerTimeout() {
        Engine.TimeScale = 1;
        GetTree().ReloadCurrentScene();
    }
}
