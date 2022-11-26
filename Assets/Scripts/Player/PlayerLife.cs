using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    #region [variables]

    //��������� ����
    private const float _cooldown = 0.5f;

    [SerializeField]
    private Animator _activator;
    [SerializeField]
    private Rigidbody2D _solidBody;
    [SerializeField]
    private SpriteRenderer _playerSprites;

    private PlayerDefence _playerDP;
    private PlayerHealth _playerHP;

    #endregion

    #region [methods]

    void Start()
    {
        _activator.GetComponent<Animator>();
        _solidBody = GetComponent<Rigidbody2D>();
        _playerSprites = GetComponent<SpriteRenderer>();

        _playerDP = GetComponent<PlayerDefence>();
        _playerHP = GetComponent<PlayerHealth>();
    }

    public void TakeDamage(int damage)      /*����� ��� ��������� �����*/
    {
        MovementState state;
        state = MovementState.gettingHurt;

        if (_playerDP.currentDefence < damage)
        {
            _playerHP.currentHealth -= (damage - _playerDP.currentDefence);

            if (_playerHP.currentHealth <= 0)
            {
                Die();
            }
            else
            {
                _activator.SetInteger("state", (int)state);
                StartCoroutine(Delay());
            }
        }
    }

    private void Die()      /*����� ��� ������� ������� �����*/
    {
        _playerHP.currentHealth = 0;

        _activator.SetTrigger("death");
        _solidBody.bodyType = RigidbodyType2D.Static;
    }

    private void StopHurt()
    {
        _playerSprites.color = Color.white;
        StopAllCoroutines();
    }

    IEnumerator Delay()
    {
        _playerSprites.color = Color.red;
        yield return new WaitForSeconds(_cooldown);

        _playerSprites.color = Color.white;
        yield return new WaitForSeconds(_cooldown);
    }

    #endregion
}
