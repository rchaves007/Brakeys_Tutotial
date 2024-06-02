using Godot;

namespace BrakeysTutorial.scripts;

public partial class CustomSignals : Node {
    [Signal]
    public delegate void AddCoinsEventHandler(int coinValue);
}
