using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Utility;
using Cinemachine;

/**
    Switches between cameras for the maze, there might be an easier way to switch between confiners
    but I had this from a previous project

    - Might get deleted/unused depending on the final maze asset layout
    - this script is on all virtual cameras in the scene
**/
public class MoveBetweenSpaces : MonoBehaviour
{
    public CinemachineVirtualCamera newCamera; //Camera being switched to
    public CinemachineBrain mainCameraBrain; //Main camera
    private ICinemachineCamera currentCamera;

    bool playerDetected;
    
    GameObject playerGO;
    void Start(){
        playerDetected = false;
    }

    void Update(){
        if(playerDetected){
            currentCamera = mainCameraBrain.ActiveVirtualCamera;
                if(newCamera != (Object)currentCamera){ //if new camera is not the current camera, switch
                    currentCamera.VirtualCameraGameObject.SetActive(false);
                    newCamera.VirtualCameraGameObject.SetActive(true);
                }
            playerDetected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerDetected = true;
            playerGO = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerDetected = false;
        }
    }
}
