using LevelGeneration;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private LevelGenerationBootstrap _levelGenerationBootstrap;
    [SerializeField]
    private CoroutinePlayer _coroutinePlayer;

    [Space]
    [SerializeField]
    private UIMenuHolder _UIMenuHolder;

    [Space]
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Transform _playerHolder;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Transform _playerStartPosition;
    [SerializeField]
    private MovementInput _movementInput;
    [SerializeField]
    private Transform _cubesParent;

    [Space]
    [SerializeField]
    private PlayerConfig _playerConfig;

    [Space]
    [SerializeField]
    private CubesHoldeEffects _cubesHoldeEffects;
    [SerializeField]
    private MovementEffects _movementEffects;

    private UIMenuOpener _UIMenuOpener;
    private LevelLoseChecker _levelLoseChecker;
    private PlayerMover _playerMover;
    private CubesHolder _cubesHolder;
    private LevelGenerator _levelGenerator;

    private Level _currentLevel;

    private void Awake()
    {
        InitializeCubesHolder();
        InitializePlayerMover();
        InitializeLevel();

        InitializeLevelGenerator();
    }

    private void InitializeLevel()
    {
        _levelLoseChecker = new LevelLoseChecker(_cubesHolder, _player);
        _UIMenuOpener = new UIMenuOpener();
        _currentLevel = new Level(_UIMenuHolder, _UIMenuOpener, _movementInput,
            _levelLoseChecker, _player, _playerMover, _movementInput);
        _currentLevel.InitializeStateMachine();
    }

    private void InitializePlayerMover()
    {
        _playerMover = new PlayerMover(_playerTransform, _playerHolder, _coroutinePlayer, _playerConfig, _movementEffects);
        _movementInput.Initialize(_playerMover);
        _playerMover.SetHolderPlayerXZPosition(_playerStartPosition.position);
    }

    private void InitializeLevelGenerator()
    {
        _levelGenerator = _levelGenerationBootstrap.Initialize(_player, _cubesHolder, _playerConfig.CubePrefab);
    }

    private void InitializeCubesHolder()
    {
        _cubesHolder = new CubesHolder(_player, _cubesParent, _cubesHoldeEffects);

        for (int i = 0; i < _playerConfig.StartNumberOfCubes; i++)
        {
            _cubesHolder.AddCubeAsInitial(_playerConfig.CubePrefab);
        }
    }
}
