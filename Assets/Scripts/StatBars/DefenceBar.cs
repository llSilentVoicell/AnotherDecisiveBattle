using UnityEngine;
using UnityEngine.UI;

public class DefenceBar : MonoBehaviour
{
    private Slider _defenceValue;

    private void Start()
    {
        _defenceValue = GetComponent<Slider>();
    }

    public void SetMaxDefence(int defence)         /*Метод для встановлення максимального значення захисту*/
    {
        _defenceValue.maxValue = defence;
        _defenceValue.value = defence;
    }

    public void SetCurrentDefence(int defence)      /*Метод для встановлення поточного значення захисту*/
    {
        _defenceValue.value = defence;
    }
}
