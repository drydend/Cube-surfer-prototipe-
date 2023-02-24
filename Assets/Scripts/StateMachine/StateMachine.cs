using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, BaseState> _states = new Dictionary<Type, BaseState>();

    private BaseState _currentState;

    public StateMachine(Dictionary<Type, BaseState> states)
    {
        _states = states;
    }

    public void EnterInitialState<State>()
    {
        if (!_states.ContainsKey(typeof(State)))
        {
            throw new System.Exception($"State machine does no contains state of type: {typeof(State)}");
        }

        _currentState = _states[typeof(State)];
        _currentState.Enter();
    }

    public void SwitchState<State>()
    {
        if (!_states.ContainsKey(typeof(State)))
        {
            throw new System.Exception($"State machine does no contains state of type: {typeof(State)}");
        }

        _currentState.Exit();
        _currentState = _states[typeof(State)];
        _currentState.Enter();
    }
}
