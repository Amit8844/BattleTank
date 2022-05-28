using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class is Attached to a Player Tank GameObject and is responsible for rendering and UI related work.
/// </summary>
public class TankView : MonoBehaviour, IDamagable
{
    public GameObject Turret;
    public Transform BulletSpawner;
    private TankController tankController;
    public Image HealthBar;

    public ParticleSystem TExplode;
    public AudioSource TrackAudio;




    private void Start()
    {
        tankController.SubscribeEvents();
       

    }

    

    private void FixedUpdate()
    {
        tankController.HandleLeftJoyStickInput(GetComponent<Rigidbody>());
        TrackAudio.Play();  
        tankController.HandleRightJoyStickInput(Turret.transform);
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           tankController.DestroyWorld();
        }

        tankController.SetHealthUI();

    }

    // Sets a reference to the corresponding TankController Script.
    public void SetTankControllerReference(TankController controller)
    {
        tankController = controller;
    }

    // Implements the method of IDamagable interface to be able to take damage.
    public void TakeDamage(float damage)
    {
       // Debug.Log("Player Tank Taking Damage: " + damage, gameObject);
        tankController.ApplyDamage(damage);
        
    }

    private void OnDisable()
    {
        tankController.UnsubscribeEvents();
    }

}
