using UnityEngine;

public class EnemyDefence : MonoBehaviour
{
    #region [variables]

    //��������� ����
    [SerializeField]
    private int _maxDefence;

    public int currentDefence;

    #endregion

    #region [methods]

    void Start()
    {
        currentDefence = _maxDefence;
    }

    #endregion
}
