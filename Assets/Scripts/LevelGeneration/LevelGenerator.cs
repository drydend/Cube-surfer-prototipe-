using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class LevelGenerator : IUpdateable
    {
        private Transform _chunksParent;
        private LevelGeneratorConfig _config;
    
        private Player _player;
        private CubesHolder _cubesHolder;
        private StackableCube _stackableCubePrefab;

        private List<LevelChunk> _generatedChunks = new List<LevelChunk>();

        public LevelGenerator(Transform chunksParent, LevelGeneratorConfig config, Player player, 
            CubesHolder cubesHolder, StackableCube stackableCubePrefab)
        {   
            _chunksParent = chunksParent;
            _config = config;

            _player = player;
            _cubesHolder = cubesHolder;
            _stackableCubePrefab = stackableCubePrefab;
        }

        public void SpawnStartChunk()
        {
            var chunk = UnityEngine.Object.Instantiate(_config.StartChunk, _chunksParent);
            chunk.Initialize(_cubesHolder, _stackableCubePrefab);
            chunk.transform.SetParent(_chunksParent);
            chunk.transform.localPosition = Vector3.zero;
            _generatedChunks.Add(chunk);
        }

        public bool TrySpawnRandomChunks(int numberOfChunks)
        {
            numberOfChunks = _generatedChunks.Count + numberOfChunks > _config.MaxNumberOfChunks
                ? _config.MaxNumberOfChunks - _generatedChunks.Count : numberOfChunks;

            for (int i = 0; i < numberOfChunks; i++)
            {
                SpawnRandomChunk();
            }

            return numberOfChunks > 0;
        }

        public void Update()
        {
            var xzPlayerProjection = new Vector2(_player.transform.position.x, _player.transform.position.z);

            CheckDistanceToLastChunk(xzPlayerProjection);
        }   

        private void CheckDistanceToLastChunk(Vector2 xzPlayerProjection)
        {
            var lastGeneratedChunkEndPoint = _generatedChunks[_generatedChunks.Count - 1].EndPoint;
            var xzLastGeneratedChunkEndProjection = new Vector2(lastGeneratedChunkEndPoint.transform.position.x,
                lastGeneratedChunkEndPoint.position.z);

            if (Vector2.Distance(xzPlayerProjection, xzLastGeneratedChunkEndProjection) < _config.NewChunkSpawnDistance
                && _generatedChunks.Count < _config.MaxNumberOfChunks)
            {
                SpawnRandomChunk();
            }
        }

        private void SpawnRandomChunk()
        {
            var chunk = UnityEngine.Object.Instantiate(_config.LevelChunks.GetRandomElement(), _chunksParent);
            chunk.Initialize(_cubesHolder, _stackableCubePrefab);
            
            if(_generatedChunks.Count == 0)
            {
                chunk.transform.SetParent(_chunksParent);
                chunk.transform.localPosition = Vector3.zero;
            }
            else
            {
                var chunkPosition = _generatedChunks[_generatedChunks.Count - 1].EndPoint.position 
                    - chunk.StartPoint.localPosition;
                chunk.transform.position = chunkPosition;
                chunk.transform.SetParent(_chunksParent);
            }
            
            _generatedChunks.Add(chunk);
            
            if(_generatedChunks.Count == _config.MaxNumberOfChunks)
            {
                DeleteFirstChunk();
            }
        }

        private void DeleteFirstChunk()
        {
            var chunk = _generatedChunks[0];
            _generatedChunks.RemoveAt(0);

            UnityEngine.Object.Destroy(chunk.gameObject);
        }
    }
}
