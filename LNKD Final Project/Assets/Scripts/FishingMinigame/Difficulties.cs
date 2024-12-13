using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulties : MonoBehaviour
{
    public FishingMiniGame fishing;

    [Header("easy difficulty values")]
    [SerializeField] float timerMultiplier1 = 3f;
    [SerializeField] float hookSize1 = 0.2f;
    [SerializeField] float hookPower1 = 0.3f;
    [SerializeField] float hookProgressDegradtionPower1 = 0.1f;

    [Header("medium difficulty values")]
    [SerializeField] float timerMultiplier2 = 0.5f;
    [SerializeField] float hookSize2 = 0.18f;
    [SerializeField] float hookPower2 = 0.22f;
    [SerializeField] float hookProgressDegradtionPower2 = 0.2f;

    [Header("hard difficulty values")]
    [SerializeField] float timerMultiplier3 = 0.4f;
    [SerializeField] float hookSize3 = 0.15f;
    [SerializeField] float hookPower3 = 0.18f;
    [SerializeField] float hookProgressDegradtionPower3 = 0.2f;
    void Awake(){
        if(GameHandler.FishingMinigame == 0){
            fishing.timerMultiplier = timerMultiplier1;
            fishing.hookSize = hookSize1;
            fishing.hookPower = hookPower1;
            fishing.hookProgressDegradtionPower = hookProgressDegradtionPower1;
            Debug.Log("Fishing Minigame difficulty set to 1");
        }else if(GameHandler.FishingMinigame == 1){
            fishing.timerMultiplier = timerMultiplier2;
            fishing.hookSize = hookSize2;
            fishing.hookPower = hookPower2;
            fishing.hookProgressDegradtionPower = hookProgressDegradtionPower2;
            Debug.Log("Fishing Minigame difficulty set to 2");
        }else{
            fishing.timerMultiplier = timerMultiplier3;
            fishing.hookSize = hookSize3;
            fishing.hookPower = hookPower3;
            fishing.hookProgressDegradtionPower = hookProgressDegradtionPower3;
            Debug.Log("Fishing Minigame difficulty set to 3");
        }
    }
}
