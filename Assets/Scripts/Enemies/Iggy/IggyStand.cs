using UnityEngine;

public class IggyStand : MonoBehaviour
{
    #region [variables]

    //Оголошуємо змінні
    public IggyStandAttack standParams;

    [SerializeField]
    private Collider2D _standBox;

    #endregion

    #region [methods]

    void Start()
    {
        _standBox = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)     /*Нанесення урону гравцю*/
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerLife>().TakeDamage(standParams.standAttackDamage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }

    private void ActivateCollider() /*Метод активації колайдеру*/
    {
        _standBox.enabled = true;
    }

    private void Deactivate()   /*Метод деактивації дальньої атаки*/
    {
        _standBox.enabled = false;
        gameObject.SetActive(false);
    }

    #endregion
}
