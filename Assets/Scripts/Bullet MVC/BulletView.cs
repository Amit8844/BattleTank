using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is attached to the Bullet Game Object in the game.
/// </summary>
public class BulletView : MonoBehaviour
{
    [SerializeField] private AudioSource _BXAudio;
    [SerializeField] private AudioSource _BSAudio;

    public ParticleSystem BExplode;
    BulletController bulletController;
    

  

    public void Initialize(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bulletController.InflictDamage(collision.gameObject);
        BExplode.transform.parent = null;

        _BSAudio.Play();
        BExplode.Play();
       

        _BXAudio.Play();    
        Destroy(gameObject);
    }
}
