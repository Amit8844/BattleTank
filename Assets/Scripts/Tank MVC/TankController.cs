using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This Class implements all the logic which is required for a Tank Entity in the game to Operate as required.
/// </summary>
public class TankController
{
    // JoyStick & Camera References.
    private Joystick LeftJoyStick;
    private Joystick RightJoyStick;
    //public CameraController cameraController;

    // Speed variables.
    private float SpeedMultipier = 0.001f;
    private float RotationSpeedMultiplier = 0.01f;
    //private float CameraZoomOutSpeed = 0.0001f;

    private float StartingHealth = 300f;
    //public float LerpSpeed = 3f*Time.deltaTime;


    public TankModel TankModel { get; }
    public TankView TankView { get; }
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }

    // Sets the reference to left & right Joysticks on the Canvas.
    public void SetJoyStickReferences(Joystick leftJoyStick, Joystick rightJoyStick)
    {
        LeftJoyStick = leftJoyStick;
        RightJoyStick = rightJoyStick;
    }

   public Transform GetTransform()
    {
        return TankView.transform;
        
    }
    
    // Sets the reference to the Camera & makes it a child object of PLayer Tank.
    //public void SetCameraReference(Camera cameraRef)
    //{
    //  camera = cameraRef;
    //   camera.transform.SetParent(TankView.transform);
    // }

    // This Function Handles the Input from the Left Joystick.
    public void HandleLeftJoyStickInput(Rigidbody tankRigidBody)
    {
        if(LeftJoyStick.Vertical != 0)
        {
            Vector3 ZAxisMovement = tankRigidBody.transform.position + (tankRigidBody.transform.forward * LeftJoyStick.Vertical * TankModel.Speed * SpeedMultipier);
            tankRigidBody.MovePosition(ZAxisMovement);
        }
        
        if(LeftJoyStick.Horizontal != 0)
        {
            Quaternion newRotation = tankRigidBody.transform.rotation * Quaternion.Euler(Vector3.up * LeftJoyStick.Horizontal * TankModel.RotationSpeed * RotationSpeedMultiplier);
            tankRigidBody.MoveRotation(newRotation);
        }
        
    }

    // This Function Handles the Input recieved from the Right Joystick.
    public void HandleRightJoyStickInput(Transform turretTransform)
    {
        Vector3 desiredRotation = Vector3.up * RightJoyStick.Horizontal * TankModel.TurretRotationSpeed * RotationSpeedMultiplier;
        turretTransform.Rotate(desiredRotation, Space.Self);
    }

    // Calls some asynchronous methods to destroy the world gradually with a cool effect.
    public void DestroyWorld()
    {
        TankService.Instance.playerCamera.ZoomOutCamera();
        DestroyTanks();
        DestoryEnv();
    }
       
    // Destroys all Game Objects Tagged as 'Tank' one by one using async await.
    private async void DestroyTanks()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
        for (int i = 0; i < tanks.Length; i++)
        {
            GameObject.Destroy(tanks[i]);
           
          

            Debug.Log("DEad");
            await new WaitForSeconds(0.1f);
        }
    }

    // Destroys all Game Objects Tagged as 'Ground' one by one using async await.
    private async void DestoryEnv()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject.Destroy(objects[i]);
            await new WaitForSeconds(0.05f);
        }
    }

    // This method is called to inflict damage and reduce health of this tank.
    public void ApplyDamage(float damage)
    {
        TankModel.Health -= damage;
        SetHealthUI();

        if (TankModel.Health <= 0f )
        {
            DestroyWorld();
        }

        //    if (TankModel.Health - damage <= 0)
        //    {
        //        // death.
        //        DestroyWorld();
        //    }
        //    else
        //    {
        //        TankModel.Health -= damage;
        //        SetHealthUI();  
        //    }
    }



    public void SetHealthUI()
    {

        float LerpSpeed = 3f*Time.deltaTime;
        TankView.HealthBar.fillAmount = Mathf.Lerp(TankView.HealthBar.fillAmount, TankModel.Health / StartingHealth, LerpSpeed);
        Color HealthColor = Color.Lerp(Color.red, Color.green, (TankModel.Health/StartingHealth ));
        TankView.HealthBar.color = HealthColor;

    }


    public void SubscribeEvents()
    {
        EventHandler.Instance.OnBulletFired += FiredBullet;
    }

    public void UnsubscribeEvents()
    {
        EventHandler.Instance.OnBulletFired -= FiredBullet;
    }

    public void FiredBullet()
    {
        TankModel.BulletsFired++;
        Debug.Log(TankModel.BulletsFired);
        AchievementSystem.Instance.BulletsFiredCountCheck(TankModel.BulletsFired);
    }


}
