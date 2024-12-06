using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDifficulties : MonoBehaviour
{
    public GameManager managing;
    [SerializeField] GameObject easy;
    [SerializeField] GameObject medium;
    [SerializeField] GameObject hard;
    void Awake(){
        if(GameHandler.RhythumMinigame == 0){
            PlayerPrefs.SetInt("max",19400);
            medium.SetActive(false);
            hard.SetActive(false);
            easy.SetActive(true);
            Debug.Log("Rhythmn game difficulty set to 1");

        }else if(GameHandler.RhythumMinigame == 1){
            PlayerPrefs.SetInt("max",26400);
            medium.SetActive(true);
            hard.SetActive(false);
            easy.SetActive(false);
            Debug.Log("Rhythmn game difficulty set to 2");
        }else{
            PlayerPrefs.SetInt("max",42800);
            medium.SetActive(false);
            hard.SetActive(true);
            easy.SetActive(false);
            Debug.Log("Rhythmn game difficulty set to 3");
        }
    }
}
