using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MenuSet;
    public GameObject OverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Cancel"))
        {
            if (MenuSet.activeSelf)
                MenuSet.SetActive(false);
            else
                MenuSet.SetActive(true);

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
    }
}
