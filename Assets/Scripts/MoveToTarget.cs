using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Right,
    Left
}

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopedTime;
    [SerializeField] private Direction _startDirection;
    [SerializeField] private UnityEvent OnReachedRight;
    [SerializeField] private UnityEvent OnReachedLeft;
    private Direction _direction;
    private int _dirCoefficient;
    private bool _isStoped;

    private void Start()
    {
        _direction = _startDirection;
        _rightPoint.parent = null;
        _leftPoint.parent = null;

        _dirCoefficient = _direction == Direction.Right ? -1 : 1;
    }

    private void Update()
    {
        if (_isStoped)
        {
            return;
        }

        transform.position += _dirCoefficient * _speed * Time.deltaTime * transform.forward;

        if (_direction == Direction.Left)
        {
            if (transform.position.x < _leftPoint.position.x)
            {
                StopAndTurn(Direction.Right, -1, OnReachedLeft, _leftPoint.position.x);
            }
        }
        else
        {
            if (transform.position.x > _rightPoint.position.x)
            {
                StopAndTurn(Direction.Left, 1, OnReachedRight, _rightPoint.position.x);
            }
        }
    }

    private void StopAndTurn(Direction dir, int coefficient, UnityEvent @event, float positionX)
    {
        _dirCoefficient = coefficient;
        _direction = dir;
        _isStoped = true;

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);

        @event?.Invoke();

        StartCoroutine(StopTurn());
    }

    private IEnumerator StopTurn()
    {
        yield return new WaitForSeconds(_stopedTime);

        _isStoped = false;
    }
}