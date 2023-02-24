using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class LevelChunk : MonoBehaviour
    {
        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;

        [SerializeField]
        private List<Obstacle> _obstacles = new List<Obstacle>();
        [SerializeField]
        private List<CollectableCube> _collectableCubes = new List<CollectableCube>();

        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;

        public void Initialize(CubesHolder cubesHolder, StackableCube stackableCubePrefab)
        {
            InitializeObstacles(cubesHolder);
            InitializeCollectableCubes(cubesHolder, stackableCubePrefab);
        }

        private void InitializeObstacles(CubesHolder cubesHolder)
        {
            foreach (var obstacle in _obstacles)
            {
                obstacle.Initialize(cubesHolder);
            }
        }

        private void InitializeCollectableCubes(CubesHolder cubesHolder, StackableCube stackableCubePrefab)
        {
            foreach (var collectableCube in _collectableCubes)
            {
                collectableCube.Initialize(cubesHolder, stackableCubePrefab);
            }
        }
    }
}
