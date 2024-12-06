using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulties : MonoBehaviour
{
    public FishingMiniGame fishing;
    void Awake(){
        if(GameHandler.FishingMinigame == 0){
            fishing.timerMultiplier = 3f;
            fishing.hookSize = 0.2f;
            fishing.hookPower = 0.3f;
            fishing.hookProgressDegradtionPower = 0.1f;
            Debug.Log("Fishing Minigame difficulty set to 1");
        }else if(GameHandler.FishingMinigame == 1){
            fishing.timerMultiplier = 0.5f;
            fishing.hookSize = 0.18f;
            fishing.hookPower = 0.22f;
            fishing.hookProgressDegradtionPower = 0.2f;
            Debug.Log("Fishing Minigame difficulty set to 2");
        }else{
            fishing.timerMultiplier = 0.4f;
            fishing.hookSize = 0.15f;
            fishing.hookPower = 0.18f;
            fishing.hookProgressDegradtionPower = 0.2f;
            Debug.Log("Fishing Minigame difficulty set to 3");
        }
    }
}
