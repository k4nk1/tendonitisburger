using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;
    void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 30;
    }

    public void GameOver(){
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Stage");
    }
}
