using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    public bool isEnergyFull;

    [SerializeField]
    private EnergyBar _statBar;

    [SerializeField]
    private float _maxEnergy;

    public float currentEnergy;

    #endregion

    #region [methods]

    void Start()
    {
        currentEnergy = 0f;

        isEnergyFull = false;

        _statBar.SetMaxEnergy(_maxEnergy);
    }

    void Update()
    {
        if (!isEnergyFull)
        {
            if (currentEnergy < _maxEnergy)
            {
                currentEnergy += Time.deltaTime;

                isEnergyFull = false;
            }
            else
            {
                currentEnergy = _maxEnergy;
                isEnergyFull = true;
            }
        }

        _statBar.SetCurrentEnergy(currentEnergy);
    }

    #endregion
}
