using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region [variables]

        //Оголошуємо змінні
    private bool _isPaused = false;                 //чи зупинена гра
    private bool _isPauseOverlayShown = false;      //чи відкрите вікно паузи
    private bool _isDeathOverlayShown = false;      //чи відкрите вікно після смерті гравця

    [SerializeField]
    private GameObject _pauseOverlay;
    [SerializeField]
    private GameObject _deathOverlay;

    #endregion

    #region [methods]

    void Update()
    {
            //Пауза при натисканні на кнопку Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResumeGame();
        }
    }

    public void PauseResumeGame() /*Метод для паузи та продовження гри*/
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

    public void ShowHidePauseOverlay()  /*Метод для відображення вікна паузи*/
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

    public void ShowHideDeathOverlay()   /*Метод для відображення вікна після смерті*/
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

    public void RestartLevel()  /*Метод для перезапуску рівня*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ReturnToMainMenu()  /*Метод для повернення до головного меню*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ReturnToMainMenuFromEnd()   /*Метод для повернення до головного меню*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        Time.timeScale = 1;

        _deathOverlay.gameObject.SetActive(false);

        _isDeathOverlayShown = false;

        _pauseOverlay.gameObject.SetActive(false);

        _isPauseOverlayShown = false;
    }

    public void ExitProgram()   /*Метод для виходу з програми*/
    {
        Application.Quit();
    }

    public void OpenNextScene()     /*Метод для переходу до наступної сцени*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenPrevisScene()       /*Метод для переходу до попередньої сцени*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    #endregion
}
