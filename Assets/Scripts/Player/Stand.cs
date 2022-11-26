using UnityEngine;

public class Stand : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    [SerializeField]
    private float _moveSpeed;
    private bool _isNearEnemy;
    private float _dir;
    private float _lifeTimer;
    [SerializeField]
    private float _standLifeTime;

    public PlayerCombat standParams;

    [SerializeField]
    private Collider2D _standBox;
    private Animator _activator;

    #endregion

    #region [methods]

    void Start()
    {
        _activator = GetComponent<Animator>();
        _standBox = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (_isNearEnemy)
        {
            return;
        }

        float movementSpeed = _moveSpeed * Time.deltaTime * _dir;

        transform.Translate(movementSpeed, 0, 0);

        _lifeTimer += Time.deltaTime;

        if (_lifeTimer > _standLifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _isNearEnemy = true;
            _standBox.enabled = false;

            _activator.SetTrigger("punches");

            other.GetComponent<EnemyHealth>().TakeDamage(standParams.standAttackDamage);
        }

        if (other.gameObject.CompareTag("Terain"))
        {
            gameObject.SetActive(false);
        }
    }

    public void SetDirection(float direction)   /*Метод для вигначення напрямку дальньої атаки*/
    {
        _lifeTimer = 0;
        _dir = direction;

        gameObject.SetActive(true);

        _isNearEnemy = false;
        _standBox.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()   /*Метод деактивації дальньої атаки*/
    {
        gameObject.SetActive(false);
    }

    #endregion
}
