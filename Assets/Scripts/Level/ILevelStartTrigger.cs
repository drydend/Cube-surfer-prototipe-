using System;

public interface ILevelStartTrigger
{   
    event Action OnLevelStartTriggered;
    void ResetTrigger();
}