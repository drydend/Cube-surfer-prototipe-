using UnityEngine;

public class UIMenuHolder : MonoBehaviour
{
    [SerializeField]
    private UIMenu _levelStartMenu;
    [SerializeField]
    private UIMenu _levelLostMenu;
    [SerializeField]
    private UIMenu _runingLevelUI;

    public UIMenu LevelStartMenu => _levelStartMenu;
    public UIMenu LevelLostMenu => _levelLostMenu;
    public UIMenu RuningLevelUI => _runingLevelUI;
}
