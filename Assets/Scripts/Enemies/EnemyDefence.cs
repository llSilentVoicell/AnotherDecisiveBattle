using UnityEngine;

public class EnemyDefence : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
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
