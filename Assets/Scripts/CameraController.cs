using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTank;
    public Vector3 offset;
      

    private void Start()
    {
        playerTank = FindObjectOfType<TankView>().transform;
    }

    void Update()
    {
        CheckPlayer();
        transform.position = playerTank.transform.position + offset ;
    }

    private void CheckPlayer()
    {
        if(playerTank == null)
        {
            playerTank = transform;
            return;
        }
    }
   

    private void LateUpdate()
    {
        
           offset =  transform.position - playerTank.transform.position;
        
    }


   
}
