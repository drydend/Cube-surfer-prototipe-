public class LevelIdleState : BaseState
{
    private StateMachine _levelStateMachine;
    private UIMenu _idleMenu;
    private UIMenuOpener _menuOpener;
    private ILevelStartTrigger _levelStartTrigger;

    public LevelIdleState(StateMachine levelStateMachine, UIMenu idleUIMenu, UIMenuOpener menuOpener, 
        ILevelStartTrigger levelStartTrigger)
    {
        _levelStateMachine = levelStateMachine;
        _idleMenu = idleUIMenu;
        _menuOpener = menuOpener;
        _levelStartTrigger = levelStartTrigger;
    }

    public override void Enter()
    {
        _levelStartTrigger.ResetTrigger();
        _levelStartTrigger.OnLevelStartTriggered += StartLevel;
        _menuOpener.OpenUIMenu(_idleMenu);
    }

    public override void Exit()
    {
        _levelStartTrigger.OnLevelStartTriggered -= StartLevel;
        _menuOpener.CloseCurrentUIMenu();
    }

    private void StartLevel()
    {
        _levelStateMachine.SwitchState<LevelRuningState>();
    }
}

