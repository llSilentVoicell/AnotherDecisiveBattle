using UnityEngine;

public class EnemyEnergy : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    public bool isEnergyFull;

    [SerializeField]
    private float _maxEnergy;

    public float currentEnergy;

    #endregion

    #region [methods]

    void Start()
    {
        currentEnergy = 0f;

        isEnergyFull = false;
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
    }

    #endregion
}
