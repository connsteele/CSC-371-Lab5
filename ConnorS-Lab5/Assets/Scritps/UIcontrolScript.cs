using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontrolScript : MonoBehaviour
{
    public GameObject welcomeText;
    public GameObject winText;
    public GameObject playerChar;
    AudioSource musicSource;
    bool victoryAchieved;
    float welcomeTimeout;

    // Start is called before the first frame update
    void Start()
    {
        welcomeTimeout = 5.0f;
        winText.SetActive(false);
        victoryAchieved = false;
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Turn of the welcome message
        if (Time.time > welcomeTimeout)
        {
            welcomeText.SetActive(false);
        }

        // Player Wins the game!
        if (playerChar.GetComponent<fisherController>().playerScore >= 100)
        {
            winText.SetActive(true);
            victoryAchieved = true;
        }

        if (victoryAchieved == true && Input.GetMouseButton(0))
        {
            // Restart level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
