using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadWin()
    {
        SceneManager.LoadScene(4);
    }

}
