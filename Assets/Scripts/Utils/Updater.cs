using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private List<IUpdateable> _updateable = new List<IUpdateable>();

    public void AddUpdateable(IUpdateable updateable)
    {
        _updateable.Add(updateable);
    }

    public void RemoveUpdateable(IUpdateable updateable)
    {
        _updateable.Remove(updateable);
    }

    private void Update()
    {
        foreach (var updateable in _updateable)
        {
            updateable.Update();
        }
    }
}
