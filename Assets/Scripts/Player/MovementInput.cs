using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementInput : MonoBehaviour, ILevelStartTrigger, IPointerDownHandler, IPointerUpHandler
{
    private const int ReferenceWidth = 1080;

    private float _widthScale;

    [SerializeField]
    private float _inputSensitivity;

    private PlayerMover _playerMover;

    private bool _isEnabled;
    private bool _isPressed;
    private int _touchCount;

    private bool _levelStartTriggered;
    public event Action OnLevelStartTriggered;

    public void Initialize(PlayerMover playerMover)
    {
        _playerMover = playerMover;
        _widthScale = ReferenceWidth / Screen.width;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        _touchCount++;

        if (!_levelStartTriggered)
        {
            OnLevelStartTriggered?.Invoke();
            _levelStartTriggered = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _touchCount--;

        if (_touchCount == 0)
        {
            _isPressed = false;
        }
    }

    public void ResetTrigger()
    {
        _levelStartTriggered = false;
    }

    public void EnableMovementInput()
    {
        _isEnabled = true;
    }

    public void DisableMovementInput()
    {
        _isEnabled = false;
    }

    private void Update()
    {
        if (!_isEnabled || !_isPressed)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            float moveDelta = default;
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                moveDelta = touch.deltaPosition.x * _inputSensitivity * _widthScale;
            }

            _playerMover.MovePerpendicularToForwardDirection(moveDelta);
        }
    }
}
