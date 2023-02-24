public class LevelLostState : BaseState
{
    private Player _player;
    private UIMenu _levelLostMenu;
    private UIMenuOpener _UIMenuOpener;

    public LevelLostState(Player player, UIMenu uiMenu, UIMenuOpener uIMenuOpener)
    {
        _player = player;
        _levelLostMenu = uiMenu;
        _UIMenuOpener = uIMenuOpener;
    }

    public override void Enter()
    {
        _player.OnDie();
        _UIMenuOpener.OpenUIMenu(_levelLostMenu);
    }

    public override void Exit()
    {
        _UIMenuOpener.CloseCurrentUIMenu();
    }
}
