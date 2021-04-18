using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;

    public TextMesh scoreText;
    public TextMesh livesText;

    public static int score;
    public static int lives;

    public GameObject prize1;
    public GameObject prize2;
    public GameObject prize3;
    public GameObject prize4;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        score = PlayerPrefs.GetInt("PlayerSCORE");
        lives = PlayerPrefs.GetInt("PlayerLIVES");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        //PlayerPrefs.SetInt("PlayerSCORE", score);
        //PlayerPrefs.SetInt("PlayerLIVES", lives);

        checkGameOver();
        checkPrizes();

        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }

    private void Awake()
    {
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartButton()
    {
        Debug.Log("RESTARTED SCENE");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerPrefs.SetInt("PlayerLIVES", 3);
        PlayerPrefs.SetInt("PlayerSCORE", 0);
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Debug.Log("Quiting Game and going to End Scene");
        Application.Quit();
    }

    public void checkGameOver()
    {
        if (lives <= 0)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }

    public void checkPrizes()
    {
        if(!prize1.activeSelf && !prize2.activeSelf && !prize3.activeSelf && !prize4.activeSelf)
        {
            //Debug.Log("TEST");
            PlayerPrefs.SetInt("PlayerSCORE", score);
            PlayerPrefs.SetInt("PlayerLIVES", lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
