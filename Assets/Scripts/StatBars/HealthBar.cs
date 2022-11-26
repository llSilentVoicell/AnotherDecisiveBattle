using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthValue;

    private void Start()
    {
        _healthValue = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)        /*ћетод дл€ встановленн€ максимального значенн€ здоров'€*/
    {
        _healthValue.maxValue = health;
        _healthValue.value = health;
    }

    public void SetCurrentHealth(int health)    /*ћетод дл€ встановленн€ поточного значенн€ здоров'€*/
    {
        _healthValue.value = health;
    }
}
