using System;
using System.Collections.Generic;

public class Level 
{
    private UIMenuHolder _UIMenuHolder;
    private UIMenuOpener _UIMenuOpener;

    private ILevelStartTrigger _startTrigger;
    private ILevelLoseTrigger _loseTrigger;

    private Player _player;
    private PlayerMover _playerMover;
    private MovementInput _input;

    private StateMachine _stateMachine;

    public Level(UIMenuHolder uIMenuHolder, UIMenuOpener uIMenuOpener, ILevelStartTrigger startTrigger,
        ILevelLoseTrigger loseTrigger, Player player, PlayerMover playerMover, MovementInput input)
    {
        _UIMenuHolder = uIMenuHolder;
        _UIMenuOpener = uIMenuOpener;
        _startTrigger = startTrigger;
        _loseTrigger = loseTrigger;
        _player = player;
        _playerMover = playerMover;
        _input = input;
    }

    public void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>();
        _stateMachine = new StateMachine(states);

        states[typeof(LevelIdleState)] = new LevelIdleState(_stateMachine, _UIMenuHolder.LevelStartMenu,
            _UIMenuOpener, _startTrigger);
        states[typeof(LevelRuningState)] = new LevelRuningState(_stateMachine, _playerMover, _input, _loseTrigger);
        states[typeof(LevelLostState)] = new LevelLostState(_player, _UIMenuHolder.LevelLostMenu, _UIMenuOpener);

        _stateMachine.EnterInitialState<LevelIdleState>();
    }
}
