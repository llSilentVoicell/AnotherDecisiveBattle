using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider _energyValue;

    private void Start()
    {
        _energyValue = GetComponent<Slider>();
    }

    public void SetMaxEnergy(float energy)      /*Метод для встановлення максимального значення енергії*/
    {
        _energyValue.maxValue = energy;
        _energyValue.value = 0f;
    }

    public void SetCurrentEnergy(float energy)  /*Метод для встановлення поточного значення енергії*/
    {
        _energyValue.value = energy;
    }
}
