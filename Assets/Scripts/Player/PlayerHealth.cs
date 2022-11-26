using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    [SerializeField]
    private HealthBar _statBar;

    [SerializeField]
    private Text _healthText;

    [SerializeField]
    private int _maxHealth;

    public int currentHealth;

    #endregion

    #region [methods]

    private void Start()
    {
        currentHealth = _maxHealth;

        _statBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        _statBar.SetCurrentHealth(currentHealth);

        _healthText.text = currentHealth + "/" + _maxHealth;
    }

    #endregion
}
