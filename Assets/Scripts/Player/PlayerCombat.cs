using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    [SerializeField]
    private Animator _activator;
    [SerializeField]
    private PlayerMovement _playerMove;
    public PlayerEnergy energyReserve;
    [SerializeField]
    private LayerMask _enemyLayers;

    [Header("Melee attack settings")]
    [SerializeField]
    private Transform _meleeAttackPoint;
    [SerializeField]
    private float _meleeAttackRange;
    [SerializeField]
    private int _meleeAttackDamage;
    [SerializeField]
    private float _meleeAttackRate;
    [SerializeField]
    private float _nextMeleeAttackTime;

    [Header("Stand attack settings")]
    public float standEnergyConsumption;
    [SerializeField]
    private float _standAttackCooldown;
    [SerializeField]
    private Transform _standAttackPoint;
    public int standAttackDamage = 10;
    [SerializeField]
    private GameObject _stand;
    private float _standCooldownTimer = Mathf.Infinity;

    #endregion

    #region [methods]

    private void Awake()
    {
        _activator = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMovement>();

        energyReserve = GetComponent<PlayerEnergy>();
    }

    private void Update()
    {
        if (Time.time >= _nextMeleeAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                MeleeAttack();
                _nextMeleeAttackTime = Time.time + (1f / _meleeAttackRate);
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && _standCooldownTimer > _standAttackCooldown && _playerMove.CanStandAttack())
        {
            AttackWithStand();
        }

        _standCooldownTimer += Time.deltaTime;
    }

    private void MeleeAttack()  /*Метод реалізації ближньої атаки*/
    {
        _activator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_meleeAttackPoint.position, _meleeAttackRange, _enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(_meleeAttackDamage);
        }
    }

    private void AttackWithStand()  /*Метод реалізації дальної атаки*/
    {
        _activator.SetTrigger("standAttack");

        energyReserve.currentEnergy -= standEnergyConsumption;
        energyReserve.isEnergyFull = false;

        _standCooldownTimer = 0;

        _stand.transform.position = _standAttackPoint.position;
        _stand.GetComponent<Stand>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void OnDrawGizmosSelected() /*Метод для відображення зони атаки в редакторі*/
    {
        if (_meleeAttackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_meleeAttackPoint.position, _meleeAttackRange);
    }

    #endregion
}
