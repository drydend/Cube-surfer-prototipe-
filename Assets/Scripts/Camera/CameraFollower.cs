using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _positionOffset;

    public void Start()
    {
        transform.position = _target.position + _positionOffset;
    }

    public void LateUpdate()
    {
        transform.position = _target.position + _positionOffset;
    }
}
