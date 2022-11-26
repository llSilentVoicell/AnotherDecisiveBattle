using UnityEngine;
using UnityEngine.UI;

public class DefenceBar : MonoBehaviour
{
    private Slider _defenceValue;

    private void Start()
    {
        _defenceValue = GetComponent<Slider>();
    }

    public void SetMaxDefence(int defence)         /*����� ��� ������������ ������������� �������� �������*/
    {
        _defenceValue.maxValue = defence;
        _defenceValue.value = defence;
    }

    public void SetCurrentDefence(int defence)      /*����� ��� ������������ ��������� �������� �������*/
    {
        _defenceValue.value = defence;
    }
}
