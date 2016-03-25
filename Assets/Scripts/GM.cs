using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject youWin;
    [SerializeField]
    GameObject youLose;
    [SerializeField]
    GameObject menu;

    public static GM instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetButtonDown("Escape"))
        {
            pause.SetActive(true);
            //Debug.Log("Pause");
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Tab"))
        {
            pause.SetActive(false);
            menu.SetActive(false);
            //Debug.Log("Unpause");
            Time.timeScale = 1;
        }
        else if (Input.GetButtonDown("Quit"))
        {
            //Debug.Log("Quit!");
            Application.Quit();
        }
    }

    public void GameLost()
    {
        Time.timeScale = 0;
        youLose.SetActive(true);
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        youWin.SetActive(true);
    }
}
