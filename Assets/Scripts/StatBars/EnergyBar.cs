using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider _energyValue;

    private void Start()
    {
        _energyValue = GetComponent<Slider>();
    }

    public void SetMaxEnergy(float energy)      /*����� ��� ������������ ������������� �������� ����㳿*/
    {
        _energyValue.maxValue = energy;
        _energyValue.value = 0f;
    }

    public void SetCurrentEnergy(float energy)  /*����� ��� ������������ ��������� �������� ����㳿*/
    {
        _energyValue.value = energy;
    }
}
