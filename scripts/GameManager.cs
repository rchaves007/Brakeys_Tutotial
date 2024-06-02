using Godot;

namespace BrakeysTutorial.scripts;

public partial class GameManager : Node {
    private CustomSignals _customSignals;
    private int _score;
    private Label _scoreLabel;

    public override void _Ready() {
        _customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        _customSignals.AddCoins += OnAddCoins;

        _scoreLabel = GetNode<Label>("ScoreLabel");
    }

    protected override void Dispose(bool disposing) {
        _customSignals.AddCoins -= OnAddCoins;
    }

    private void OnAddCoins(int coinValue = 1) {
        _score += coinValue;

        _scoreLabel.Text = $"You collected {_score} coins";
    }
}
