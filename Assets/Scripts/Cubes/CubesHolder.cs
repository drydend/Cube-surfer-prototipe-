using System;
using System.Collections.Generic;
using UnityEngine;

public class CubesHolder
{   
    private Transform _cubesParent;
    private Player _player;
    private CubesHoldeEffects _effects;

    public List<StackableCube> ControledCubes { get; private set; }

    public event Action<int> OnNumberOfCubesChaged;

    public CubesHolder(Player player, Transform cubesParent, CubesHoldeEffects cubesHoldeEffects)
    {
        _player = player;
        _cubesParent = cubesParent;
        _effects = cubesHoldeEffects;   
        ControledCubes = new List<StackableCube>();
    }

    public StackableCube AddCubeAsInitial(StackableCube cubePrefab)
    {
        var cubeInstance = UnityEngine.Object.Instantiate(cubePrefab, _player.transform);

        Vector3 cubePosition;

        if (ControledCubes.Count > 0)
        {
            cubePosition = new Vector3(_player.transform.position.x,
          ControledCubes[ControledCubes.Count - 1].transform.position.y + cubePrefab.CubeHeight
          , _player.transform.position.z);
        }
        else
        {
            cubePosition = new Vector3(_player.transform.position.x,
            _player.transform.position.y + cubePrefab.CubeHeight, _player.transform.position.z);
        }

        cubeInstance.transform.position = cubePosition;
        cubeInstance.transform.SetParent(_cubesParent, true);

        var characterPosition = new Vector3(_player.transform.position.x,
            _player.transform.position.y + cubePrefab.CubeHeight, _player.transform.position.z);
        _player.transform.position = characterPosition;

        cubeInstance.OnControlled();

        ControledCubes.Add(cubeInstance);
        
        return cubeInstance;
    }

    public void AddCube(StackableCube cubePrefab)
    {
        var cubeInstance = AddCubeAsInitial(cubePrefab);

        _player.Jump();
        _effects.PlayCubeAddedEffects(cubeInstance);
        OnNumberOfCubesChaged?.Invoke(ControledCubes.Count);
    }

    public void RemoveCube(StackableCube cube)
    {
        cube.OnUncontrolled();
        cube.transform.parent = null;
        
        ControledCubes.Remove(cube);
        
        _effects.PlayerCubeRemovedEffect();
        OnNumberOfCubesChaged?.Invoke(ControledCubes.Count);
    }
}
