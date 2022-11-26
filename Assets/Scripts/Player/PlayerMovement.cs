using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    private Collider2D _playerBox;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private Transform _playerTrans;

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;

    public Rigidbody2D solidBody;
    public Animator activator;

    private float _dirX = 0f;

    public PlayerEnergy energyReserve;

    [SerializeField]
    private PlayerCombat _playerCombat;

    #endregion

    #region [methods]

    void Start()
    {
        solidBody = GetComponent<Rigidbody2D>();
        _playerBox = GetComponent<Collider2D>();

        activator = GetComponent<Animator>();

        _playerTrans = GetComponent<Transform>();

        energyReserve = GetComponent<PlayerEnergy>();
        _playerCombat = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if (solidBody.bodyType == RigidbodyType2D.Dynamic)
        {
            _dirX = Input.GetAxisRaw("Horizontal");

            solidBody.velocity = new Vector2(_dirX * _moveSpeed, solidBody.velocity.y);

            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)
                || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
            {
                solidBody.velocity = new Vector2(solidBody.velocity.x, _jumpForce);
            }

            UpdateAnimationState();
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (_dirX > 0f)
        {
            state = MovementState.walking;
            _playerTrans.localScale = new Vector3(1, 1, 1);
        }
        else if (_dirX < 0f)
        {
            state = MovementState.walking;
            _playerTrans.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            state = MovementState.standing;
        }

        if (solidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (solidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        activator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        bool isGrounded;

        isGrounded = Physics2D.BoxCast(_playerBox.bounds.center,
            _playerBox.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

        return isGrounded;
    }

    public bool CanStandAttack()
    {
        bool canStandAttack;

        canStandAttack = _dirX == 0f && IsGrounded() && 
            energyReserve.currentEnergy >= _playerCombat.standEnergyConsumption;

        return canStandAttack;
    }

    #endregion
}
