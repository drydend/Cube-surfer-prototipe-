using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StackableCube : MonoBehaviour
{
    [SerializeField]
    private float _cubeHeight = 1;
    public bool IsControlled  { get; private set; }
    public float CubeHeight => _cubeHeight;

    public void OnControlled()
    {
        IsControlled = true;
    }

    public void OnUncontrolled()
    {
        IsControlled = false;
    }
}
