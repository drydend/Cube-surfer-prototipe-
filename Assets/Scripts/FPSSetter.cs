using UnityEngine;

public class FPSSetter : MonoBehaviour
{
    private void Start()
    {   
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate + 10;
    }
}
