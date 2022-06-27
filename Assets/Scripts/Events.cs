using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayLevel() //replay level
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene() .buildIndex);
    }

    public void QuitGame() //Quit Game
    {
        SceneManager.LoadScene("StartScene") ;
    }
}
