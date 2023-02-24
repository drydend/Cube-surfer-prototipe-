using LevelGeneration;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level generator config", fileName = "Level Generator Config")]
public class LevelGeneratorConfig : ScriptableObject
{
    [SerializeField]
    private List<LevelChunk> _levelChunks;
    [SerializeField]
    private LevelChunk _startChunk;
    [SerializeField]
    private float _newChunkSpawnDistance;
    [SerializeField]
    private int _maxNumberOfChunks;
    [SerializeField]
    [Range(0, 10)]
    private int _startNumberOfChunks;

    public List<LevelChunk> LevelChunks => _levelChunks;
    public LevelChunk StartChunk => _startChunk;
    public float NewChunkSpawnDistance => _newChunkSpawnDistance;
    public int MaxNumberOfChunks => _maxNumberOfChunks;
    public int StartNumberOfChunks => _startNumberOfChunks;
}
