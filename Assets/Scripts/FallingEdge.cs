using Cinemachine;
using UnityEngine;

public class FallingEdge : MonoBehaviour
{
    #region [variables]

    //ќголошуЇмо зм≥нн≥
    [SerializeField]
    private CinemachineVirtualCamera _mainCamera;

    [SerializeField]
    private Transform _edge;

    #endregion

    #region [methods]

    private void Start()
    {
        _edge = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mainCamera.Follow = _edge;

            Die(other);
        }
    }

    private void Die(Collider2D other)      /**ћетод дл€ запуску процесу смерт≥ гравц€*/
    {
        other.gameObject.GetComponent<PlayerHealth>().currentHealth = 0;

        other.gameObject.GetComponent<PlayerMovement>().activator.SetTrigger("death");
    }

    #endregion
}
