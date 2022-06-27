using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonGeneric<GameManager>
{
    [SerializeField] private CanvasRenderer GameOverPanel;
    [SerializeField] private CanvasRenderer TankPanel;

   

   

    public  void G_ameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
    }

    public void ReplayLevel() //replay level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() //Quit Game
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void LetsRoll()
    {
        SceneManager.LoadScene("Game");
    }

    public void Tanks()
    {
        TankPanel.gameObject.SetActive(true);
    }

    

}
