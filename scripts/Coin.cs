using Godot;

namespace BrakeysTutorial.scripts;

public partial class Coin : Area2D {
    private AnimationPlayer _animationPlayer;
    private CustomSignals _customSignals;

    [Export] public int CoinValue = 1;

    public override void _Ready() {
        _customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    private void OnBodyEntered(Node2D body) {
        _customSignals.EmitSignal(nameof(CustomSignals.AddCoins), CoinValue);
        _animationPlayer.Play("pickup");
    }
}
