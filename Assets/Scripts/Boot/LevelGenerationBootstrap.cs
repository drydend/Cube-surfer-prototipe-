using LevelGeneration;
using UnityEngine;

public class LevelGenerationBootstrap : MonoBehaviour
{
    [SerializeField]
    private Transform _chunksParent;
    [SerializeField]
    private LevelGeneratorConfig _config;
    [SerializeField]
    private Updater _updater;

    public LevelGenerator Initialize(Player player, CubesHolder cubesHolder, StackableCube stackableCubePrefab)
    {
        var levelGenerator = new LevelGenerator(_chunksParent, _config, player, cubesHolder, stackableCubePrefab);
        _updater.AddUpdateable(levelGenerator); 
        levelGenerator.SpawnStartChunk();
        levelGenerator.TrySpawnRandomChunks(_config.StartNumberOfChunks);

        return levelGenerator;
    }
}