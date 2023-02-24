public class LevelRuningState : BaseState
{
    private StateMachine _levelStateMachine;
    private PlayerMover _playerMover;
    private MovementInput _movementInput;
    private ILevelLoseTrigger _levelLoseTrigger;

    public LevelRuningState(StateMachine levelStateMachine, PlayerMover playerMover, 
        MovementInput movementInput, ILevelLoseTrigger levelLoseTrigger)
    {
        _levelStateMachine = levelStateMachine;
        _playerMover = playerMover;
        _movementInput = movementInput;
        _levelLoseTrigger = levelLoseTrigger;
    }

    public override void Enter()
    {
        _levelLoseTrigger.OnLostLevel += OnLostLevel;
        _playerMover.StartMovingForward();
        _movementInput.EnableMovementInput();
    }

    public override void Exit()
    {
        _playerMover.StopMovingForward();
        _movementInput.DisableMovementInput();
    }

    private void OnLostLevel()
    {
        _levelStateMachine.SwitchState<LevelLostState>();
    }
}
