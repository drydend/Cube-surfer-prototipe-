using System.Collections;
using UnityEngine;

public class PlayerMover
{
    private Transform _player;
    private Transform _playerHolder;
    private ICoroutinePlayer _coroutinePlayer;
    private MovementEffects _movementEffects;

    private Vector3 _forwardMoveDirection;
    private float _forwardMoveSpeed;

    private float _moveSpeed;
    private float _maxDispacement;

    private Coroutine _movementCoroutine;

    public PlayerMover(Transform player, Transform playerHolder,
        ICoroutinePlayer coroutinePlayer, PlayerConfig playerConfig, MovementEffects movementEffects)
    {
        _player = player;
        _coroutinePlayer = coroutinePlayer;
        _playerHolder = playerHolder;
        _movementEffects = movementEffects;

        _forwardMoveDirection = playerConfig.InitialForwardMoveDirection;
        _forwardMoveSpeed = playerConfig.ForwardMoveSpeed;
        _moveSpeed = playerConfig.MoveSpeed;
        _maxDispacement = playerConfig.MaxDispacement;
    }

    public void SetHolderPlayerXZPosition(Vector3 position)
    {
        position.y = _player.position.y;
        _playerHolder.position = position;
    }

    public void MovePerpendicularToForwardDirection(float moveDelta)
    {
        var perpendicular = new Vector3(_forwardMoveDirection.z, 0, _forwardMoveDirection.x * -1);

        var newPosition = _player.position + perpendicular * moveDelta * _moveSpeed;

        if (Vector2.Distance(_playerHolder.position, newPosition) > _maxDispacement)
        {
            var displacementDirection = moveDelta >= 0 ? 1 : -1;
            _player.position = _playerHolder.transform.position + perpendicular * _maxDispacement * displacementDirection;
        }
        else
        {
            _player.position = newPosition;
        }
    }

    public void StartMovingForward()
    {
        if (_movementCoroutine != null)
        {
            return;
        }

        _movementEffects.PlayMovementEffects();
        _movementCoroutine = _coroutinePlayer.StartRoutine(ForwardMovementRoutine());
    }

    public void StopMovingForward()
    {
        if (_movementCoroutine == null)
        {
            return;
        }

        _movementEffects.StopPlayingMovementEffects();
        _coroutinePlayer.StopRoutine(_movementCoroutine);
    }

    private IEnumerator ForwardMovementRoutine()
    {
        while (true)
        {
            var characterNewPosition = _playerHolder.position + _forwardMoveDirection * _forwardMoveSpeed * Time.deltaTime;
            _playerHolder.position = characterNewPosition;

            yield return null;
        }
    }
}
