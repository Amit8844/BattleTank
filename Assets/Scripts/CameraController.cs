using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTank;
    public Vector3 offset;
    public Camera camera;
    private float CameraZoomOutSpeed = 0.0001f;


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

    public async void ZoomOutCamera()  //not working

    {
        Debug.Log("Kar Le kam");
        float lerp = 0.01f;
        //camera.transform.SetParent(null);
        while (camera.orthographicSize < 30)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 30, lerp);
            lerp = lerp + CameraZoomOutSpeed;
            await new WaitForSeconds(0.01f);
        }
    }



}
