using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    TextMeshProUGUI livesText;

    [SerializeField]
    bool initLive = false;
    [SerializeField]
    GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    void ResetLives()
    {
        PlayerPrefs.SetInt("Lives", 3);
    }

    public void ReduceLives()
    {
        int Lives = PlayerPrefs.GetInt("Lives");
        Lives = Lives -1;
        PlayerPrefs.SetInt("Lives", Lives);

        if (Lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }   
    }


    public void Retry()
    {
        Time.timeScale = 1;
        ResetLives();
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;

    }


    // Update is called once per frame
    void Update( )
    {   
        if (initLive == true)
        {   
            ResetLives();
            initLive = false;
        }

        livesText.text = "Lives = " + PlayerPrefs.GetInt("Lives");
    }
}
