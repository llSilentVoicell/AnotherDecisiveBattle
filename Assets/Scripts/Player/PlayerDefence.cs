using UnityEngine;
using UnityEngine.UI;

public class PlayerDefence : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    [SerializeField]
    private DefenceBar _statBar;

    [SerializeField]
    private Text _defenceText;

    [SerializeField]
    private int _maxDefence;

    public int currentDefence;

    #endregion

    #region [methods]

    void Start()
    {
        currentDefence = _maxDefence;

        _statBar.SetMaxDefence(_maxDefence);
    }

    void Update()
    {
        _statBar.SetCurrentDefence(currentDefence);

        _defenceText.text = currentDefence + "/" + _maxDefence;
    }

    #endregion
}
