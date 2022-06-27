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

    //public void BlueTankSelected()
    //{
    //       Debug.Log("Blue tank clicked!");
    //        TankType blue = TankType.Blue;
        
    //        this.gameObject.SetActive(false);

    //}
    //public void GreenTankSelected()
    //{
    //    Debug.Log("Blue tank clicked!");
    //    tankSpawner.SpawnTank(TankTypes.GreenTank);
    //    this.gameObject.SetActive(false);

    //}
    //public void RedTankSelected()
    //{
    //    Debug.Log("Blue tank clicked!");
    //    tankSpawner.SpawnTank(TankTypes.RedTank);
    //    this.gameObject.SetActive(false);
    //}


}
