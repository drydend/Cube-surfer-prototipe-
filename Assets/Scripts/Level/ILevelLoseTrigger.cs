using System;

public interface ILevelLoseTrigger
{
    event Action OnLostLevel;
    void ResetTrigger();
}