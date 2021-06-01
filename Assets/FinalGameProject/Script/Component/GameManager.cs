using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MenuSet;
    public GameObject OverPanel;

    void Start()
    {
        
    }

    void Update()
    {
        Menu();
    }
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuSet.activeSelf)
            {
                MenuSet.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                MenuSet.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void GameExit()
    {
        Application.Quit();
    }
    
    public void GameOver()
    {
        OverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        MenuSet.SetActive(false);
        Time.timeScale = 1f;
        GameObject.Find("Chicken").GetComponent<PlayerMove>().isDead = !GameObject.Find("Chicken").GetComponent<PlayerMove>().isDead;
    }
}
