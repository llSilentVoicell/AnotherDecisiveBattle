using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    #region [variables]

        //Оголошуємо змінні
    [Header("Patrol points")]
    [SerializeField]
    private Transform _leftEdge;
    [SerializeField]
    private Transform _rightEdge;

    [Header("Enemy")]
    [SerializeField]
    private Transform _enemy;

    [Header("Movement parameters")]
    [SerializeField]
    private float _movementSpeed;
    private Vector3 _initScale;
    private bool _isMovingLeft;

    [Header("Idle behaviour")]
    [SerializeField]
    private float _stanceDuration;
    private float _stanceTimer = 0;

    [Header("Enemy Animator")]
    [SerializeField]
    private Animator _activator;
    private MovementState _state;

    #endregion

    #region [methods]

    private void Start()
    {
        _initScale = _enemy.localScale;
    }

    private void Update()
    {
        if (_isMovingLeft)
        {
            if (_enemy.position.x >= _leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                ChangeDirection();
            }
        }
        else
        {
            if (_enemy.position.x <= _rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                ChangeDirection();
            }
        }
    }

    private void OnDisable()
    {
        _state = MovementState.standing;

        _activator.SetInteger("state", (int)_state);
    }

    private void MoveInDirection(int direction)     /*Метод для переміщення у перному напрямку*/
    {
        _stanceTimer = 0;

        _state = MovementState.walking;
        _activator.SetInteger("state", (int)_state);

        _enemy.localScale = new Vector3(Mathf.Abs(_initScale.x) *
            direction, _initScale.y, _initScale.z);

        _enemy.position = new Vector3(_enemy.position.x + 
            Time.deltaTime * direction *_movementSpeed, 
            _enemy.position.y, _enemy.position.z);
    }

    private void ChangeDirection()      /*Метод для зміни напрямку руху*/
    {
        _state = MovementState.standing;
        _activator.SetInteger("state", (int)_state);

        _stanceTimer += Time.deltaTime;

        if (_stanceTimer > _stanceDuration)
        {
            _isMovingLeft = !_isMovingLeft;
        }
    }

    #endregion
}
