using UnityEngine;
public class CollectableCube : MonoBehaviour
{
    private StackableCube _cubePrefab;
    private CubesHolder _cubesHolder;

    public void Initialize(CubesHolder holder, StackableCube stackableCubePrefab)
    {
        _cubesHolder = holder;
        _cubePrefab = stackableCubePrefab;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out StackableCube stackableCube))
        {
            _cubesHolder.AddCube(_cubePrefab);

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
