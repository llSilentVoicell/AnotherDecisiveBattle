using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    private const float _cooldown = 1f;

    [SerializeField]
    private SpriteRenderer _player;

    private PlayerLife _playerlife;
    private PlayerHealth _playerHP;

    [SerializeField]
    private int _damage;

    #endregion

    #region [methods]

    private void OnTriggerEnter2D(Collider2D other)
    {
        _playerlife = other.gameObject.GetComponent<PlayerLife>();
        _playerHP = other.gameObject.GetComponent<PlayerHealth>();

        if (other.gameObject.CompareTag("Player"))
        {
            _playerlife.TakeDamage(_damage);

            if (_playerHP.currentHealth > 0)
            {
                StartCoroutine(Delay(other));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player.color = Color.white;
            StopAllCoroutines();
        }
    }

    IEnumerator Delay(Collider2D other)
    {
        yield return new WaitForSeconds(_cooldown);

        OnTriggerEnter2D(other);
    }

    #endregion
}
