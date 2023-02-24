using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private CubesHolder _cubesHolder;

    private bool _isTriggered;

    public void Initialize(CubesHolder cubesHolder)
    {
        _cubesHolder = cubesHolder;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_isTriggered)
        {
            return;
        }

        if(collision.gameObject.TryGetComponent(out StackableCube cube))
        {   
            CheckCubeCollision(cube);
            return;
        }

        if(collision.gameObject.TryGetComponent(out Player player))
        {
            CheckPlayerCollision(player);
            return;
        }
    }

    private void CheckPlayerCollision(Player player)
    {   
        player.OnHitWall();

        _isTriggered = true;
    }

    private void CheckCubeCollision(StackableCube cube)
    {
        if (Mathf.Abs(cube.transform.position.y - transform.position.y - 0.01f) > (float)cube.CubeHeight / 2)
        {
            return;
        }

        if (!cube.IsControlled)
        {
            return;
        }

        _cubesHolder.RemoveCube(cube);

        _isTriggered = true;
    }
}
