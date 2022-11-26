using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    [SerializeField]
    private Animator _activator;
    [SerializeField]
    private EnemyDefence _enemyDP;
    private EnemyPatrol _patrol;
    private EnemyMeleeAttack _enemyAccess;

    [SerializeField]
    private int _maxHealth;

    public int currentHealth;

    #endregion

    #region [methods]

    void Start()
    {
        currentHealth = _maxHealth;

        _patrol = GetComponentInParent<EnemyPatrol>();
        _enemyAccess = GetComponent<EnemyMeleeAttack>();
    }

    public void TakeDamage(int damage)
    {
        if (_enemyDP.currentDefence < damage)
        {
            currentHealth -= (damage - _enemyDP.currentDefence);

            _activator.SetTrigger("hurted");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (_enemyAccess != null)
        {
            _enemyAccess.enabled = false;
        }

        if (_patrol != null)
        {
            _patrol.enabled = false;
        }

        _activator.SetBool("isDead", true);

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    #endregion
}
