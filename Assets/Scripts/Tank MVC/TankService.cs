using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class is respponsible to Create, Destroy and Manage all the Tank MVCs in the Game.
/// </summary>
public class TankService : SingletonGeneric<TankService>
{
    // Scriptable Object references.
    public PlayerTankViewList playerTankViewList;
    public TankScriptableObjectList TankList;
    public BulletScriptableObjectList BulletList;

    // UI & Camera refernces.
    public Joystick LeftJoyStick;
    public Joystick RightJoyStick;
    public Button FireButton;
    public CameraController playerCamera;

    public TankController tankController;

    public int TankType;


    private void Start()
    {
        StartGame();

    }

    private void StartGame()
    {
        tankController = CreateNewPlayerTank();
    }

    // This Function Creates a new Player Tank MVC & also set all the required references and returns the Tank Controller for the same.
    private TankController CreateNewPlayerTank()
    {
        TankModel tankModel = new TankModel(TankList.TankSOList[2]);
        TankController tankController = new TankController(tankModel, playerTankViewList.TankViewList[(int)TankType]);
        tankController.SetJoyStickReferences(LeftJoyStick,RightJoyStick);
        playerCamera.playerTank = tankController.GetTransform();

        // tankController.SetCameraReference(playerCamera);
        tankController.TankView.SetTankControllerReference(tankController);
        return tankController;
    }

    // This Function is used to communicate with Bullet Service Script when input to fire a bullet is recieved.
    public void Fire()
    {
        BulletService.Instance.FireBullet(tankController.TankView.BulletSpawner.transform, tankController.TankModel.BulletType);
        EventHandler.Instance.InvokeOnBulletFired();
    }

}
