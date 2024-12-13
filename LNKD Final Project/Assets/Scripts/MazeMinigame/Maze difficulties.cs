using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mazedifficulties : MonoBehaviour
{
    [Header("Difficulties")]
    [SerializeField] GameObject easy;
    [SerializeField] GameObject medium;
    [SerializeField] GameObject hard;

    void Awake(){
        if(GameHandler.MazeMinigame == 0){
            easy.SetActive(true);
            medium.SetActive(false);
            hard.SetActive(false);
            Debug.Log("Maze difficulty set to easy");
        }else if(GameHandler.MazeMinigame == 1){
            easy.SetActive(false);
            medium.SetActive(true);
            hard.SetActive(false);
            Debug.Log("Maze difficulty set to medium");
        }else{
            easy.SetActive(false);
            medium.SetActive(false);
            hard.SetActive(true);
            Debug.Log("Maze difficulty set to hard");
        }
    }

}
