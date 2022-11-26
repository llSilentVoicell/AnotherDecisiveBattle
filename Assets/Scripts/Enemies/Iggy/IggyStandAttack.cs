using System.Collections;
using UnityEngine;

public class IggyStandAttack : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    [Header("Stand attack settings")]
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
    private float _activationDelay;
    public int standAttackDamage;
    [SerializeField]
    private float _standEnergyConsumption;

    [Header("Stand elements")]
    [SerializeField]
    private GameObject[] _standAttacks;
    [SerializeField]
    private Transform[] _standPoints;

    [Header("Enemy settings")]
    [SerializeField]
    private Collider2D _enemyCollider;
    private Animator _activator;
    private float _cooldownTimer = Mathf.Infinity;
    [SerializeField]
    private EnemyEnergy _energyReserve;

    private EnemyPatrol _patrol;

    [Header("Player interaction settings")]
    [SerializeField]
    private LayerMask _playerLayer;

    #endregion

    #region [methods]

    private void Start()
    {
        _activator = GetComponent<Animator>();
        _enemyCollider = GetComponent<Collider2D>();
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
            if (_cooldownTimer >= _attackCooldown && _energyReserve.currentEnergy >= _standEnergyConsumption)
            {
                _cooldownTimer = 0;

                _activator.SetTrigger("standAttack");

                StartCoroutine(StandAttack());
            }
        }
    }

    IEnumerator StandAttack()
    {
        for (int i = 0; i < _standAttacks.Length; i++)
        {
            _standAttacks[i].transform.position = _standPoints[i].position;

            _standAttacks[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(_activationDelay);

            if (i >= _standAttacks.Length - 1)
            {
                StopAllCoroutines();
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

        return isInSight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(_enemyCollider.bounds.center + transform.up *
            _attackRangeYOffset + transform.right * transform.localScale.x *
            _attackRange * _colliderDistance, new Vector3(_enemyCollider.bounds.size.x *
            _attackRange, _enemyCollider.bounds.size.y * _attackRangeYScale,
            _enemyCollider.bounds.size.z));
    }

    #endregion
}
