using System;

public class LevelLoseChecker : ILevelLoseTrigger
{
    private bool Triggered;
    private CubesHolder _cubesHolder;

    public event Action OnLostLevel;

    public LevelLoseChecker(CubesHolder cubesHolder, Player player)
    {
        _cubesHolder = cubesHolder;
        _cubesHolder.OnNumberOfCubesChaged += CheckNumberOfCubes;
        player.OnPlayerHitWall += LevelLost;
    }

    public void ResetTrigger()
    {
        Triggered = false;
    }

    private void CheckNumberOfCubes(int numberOfCubes)
    {
        if (numberOfCubes <= 0 && !Triggered)
        {
            LevelLost();
        }

    }
    private void LevelLost()
    {
        OnLostLevel?.Invoke();
    }
}
