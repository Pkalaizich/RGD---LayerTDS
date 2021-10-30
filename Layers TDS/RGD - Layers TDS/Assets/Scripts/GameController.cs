using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }

    public bool gameStart = false;

    public GameObject MenuCanvas;
    public GameObject healthCanvas;
    public GameObject gameOverCanvas;
    public Text endtext;
    public int totalEnemies;
    public int enemiesDestroyed;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void StartGame()
    {
        MenuCanvas.SetActive(false);
        healthCanvas.SetActive(true);
        gameStart = true;
        AkSoundEngine.PostEvent("mx", gameObject);
    }

    public void gameOver (string text)
    {
        AkSoundEngine.PostEvent("dead_character", gameObject);
        AkSoundEngine.PostEvent("menu", gameObject);
        healthCanvas.SetActive(false);
        gameStart = false;
        gameOverCanvas.SetActive(true);
        endtext.text = text;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
