using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //public void ExitGame()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (SceneManager.GetActiveScene().buildIndex == 1)
    //        {
    //            Application.Quit();
    //        }
    //        else if (SceneManager.GetActiveScene().buildIndex >= 2)
    //        {
    //            SceneManager.LoadScene(1);
    //        }
    //    }
    //}

    public void ExitGame()
    {
        Application.Quit();
    }
}
