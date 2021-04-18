using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    int startScore = 0;
    int startLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerSCORE", startScore);
        PlayerPrefs.SetInt("PlayerLIVES", startLives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
