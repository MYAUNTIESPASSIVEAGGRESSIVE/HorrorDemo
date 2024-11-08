using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void Options()
    {

    }

    public void Credits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
