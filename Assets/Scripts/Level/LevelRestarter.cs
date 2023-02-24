using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField]
    private ScreenFade _screenFade;

    public void RestartCurrentLevel()
    {
        _screenFade.FadeScreen(Restart);
    }

    private void Restart()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
    }
}
