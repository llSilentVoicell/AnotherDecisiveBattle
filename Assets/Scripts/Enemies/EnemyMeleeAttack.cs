using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    [Header("Melee attack settings")]
    [SerializeField]
    private float _attackCooldown;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _attackRangeYScale;
    [SerializeField]
    private float _attackRangeYOffset;
    [SerializeField]
    private float _colliderDistance;
    [SerializeField]
    private int _damage;

    [Header("Enemy settings")]
    [SerializeField]
    private Collider2D _enemyCollider;
    private Animator _activator;
    private float _cooldownTimer = Mathf.Infinity;

    [Header("Player interaction settings")]
    [SerializeField]
    private LayerMask _playerLayer;
    private PlayerLife _playerlife;

    private EnemyPatrol _patrol;

    #endregion

    #region [methods]

    private void Start()
    {
        _activator = GetComponent<Animator>();
        _patrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        if (_patrol != null)
        {
            _patrol.enabled = !IsPlayerInSight();
        }

        if (IsPlayerInSight())
        {
            if (_cooldownTimer >= _attackCooldown)
            {
                _cooldownTimer = 0;

                _activator.SetTrigger("meleeAttack");
            }
        }
    }

    private bool IsPlayerInSight()      /*Перевірка, чи знаходиться гравець в облаті досяжності атаки*/
    {
        bool isInSight;

        RaycastHit2D hit = Physics2D.BoxCast(_enemyCollider.bounds.center + 
            transform.up * _attackRangeYOffset + transform.right * transform.localScale.x *
            _attackRange * _colliderDistance, new Vector3(_enemyCollider.bounds.size.x *
            _attackRange, _enemyCollider.bounds.size.y * _attackRangeYScale,
            _enemyCollider.bounds.size.z), 0, Vector2.left, 0, _playerLayer);

        isInSight = hit.collider != null;

        if (isInSight)
        {
            _playerlife = hit.transform.GetComponent<PlayerLife>();
        }

        return isInSight;
    }

    private void OnDrawGizmos()     /*Метод для відображення в редакторі області атаки*/
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_enemyCollider.bounds.center + transform.up *
            _attackRangeYOffset + transform.right * transform.localScale.x *
            _attackRange * _colliderDistance, new Vector3(_enemyCollider.bounds.size.x *
            _attackRange, _enemyCollider.bounds.size.y * _attackRangeYScale,
            _enemyCollider.bounds.size.z));
    }

    private void DamagePlayer()     /*Метод для нанесення урону гравцю*/
    {
        if (IsPlayerInSight())
        {
            _playerlife.TakeDamage(_damage);
        }
    }

    #endregion
}
