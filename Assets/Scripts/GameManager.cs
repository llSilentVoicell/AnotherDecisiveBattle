using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region [variables]

        //��������� ����
    private bool _isPaused = false;                 //�� �������� ���
    private bool _isPauseOverlayShown = false;      //�� ������� ���� �����
    private bool _isDeathOverlayShown = false;      //�� ������� ���� ���� ����� ������

    [SerializeField]
    private GameObject _pauseOverlay;
    [SerializeField]
    private GameObject _deathOverlay;

    #endregion

    #region [methods]

    void Update()
    {
            //����� ��� ��������� �� ������ Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResumeGame();
        }
    }

    public void PauseResumeGame() /*����� ��� ����� �� ����������� ���*/
    {
        if (!_isPaused)
        {
            Time.timeScale = 0;

            _isPaused = true;

            ShowHidePauseOverlay();
        }
        else if (_isPaused)
        {
            Time.timeScale = 1;

            _isPaused = false;

            ShowHidePauseOverlay();
        }
    }

    public void ShowHidePauseOverlay()  /*����� ��� ����������� ���� �����*/
    {
        if (!_isPauseOverlayShown)
        {
            _pauseOverlay.gameObject.SetActive(true);

            _isPauseOverlayShown = true;
        }
        else if (_isPauseOverlayShown)
        {
            _pauseOverlay.gameObject.SetActive(false);

            _isPauseOverlayShown = false;
        }
    }

    public void ShowHideDeathOverlay()   /*����� ��� ����������� ���� ���� �����*/
    {
        if (!_isDeathOverlayShown)
        {
            _deathOverlay.gameObject.SetActive(true);

            _isDeathOverlayShown = true;
        }
        else if (_isDeathOverlayShown)
        {
            _deathOverlay.gameObject.SetActive(false);

            _isDeathOverlayShown = false;
        }
    }

    public void RestartLevel()  /*����� ��� ����������� ����*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ReturnToMainMenu()  /*����� ��� ���������� �� ��������� ����*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ReturnToMainMenuFromEnd()   /*����� ��� ���������� �� ��������� ����*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ExitProgram()   /*����� ��� ������ � ��������*/
    {
        Application.Quit();
    }

    public void OpenNextScene()     /*����� ��� �������� �� �������� �����*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenPrevisScene()       /*����� ��� �������� �� ���������� �����*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    #endregion
}
