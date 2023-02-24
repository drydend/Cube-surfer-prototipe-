using UnityEngine;

[CreateAssetMenu(menuName = "Player config", fileName = "Player Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField]
    private Vector3 _initialForwardMoveDirection;
    [SerializeField]
    private float _forwardMoveSpeed;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _maxDispacement;
    [SerializeField]
    [Range(0, 10)]
    private int _startNumberOfCubes;
    [SerializeField]
    private StackableCube _cubePrefab;

    public Vector3 InitialForwardMoveDirection => _initialForwardMoveDirection;
    public float ForwardMoveSpeed => _forwardMoveSpeed;
    public float MoveSpeed => _moveSpeed;
    public float MaxDispacement => _maxDispacement;
    public int StartNumberOfCubes => _startNumberOfCubes;
    public StackableCube CubePrefab => _cubePrefab;
}