using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // current love score with temu
    public static int MazeMinigame = 0;
    public static int RhythymMinigame = 0;
    public static int FishingMinigame = 0;

    [Header("Game Systems")]
    public GameObject closedDoor;
    public GameObject openDoor;
    public Canvas panner;
    public ScreenDarkener ScreenDarkener;

    // private bool winstopper = false;
    

    // Start is called before the first frame updat
    void Start() {
        panner.enabled = true;
        ScreenDarkener.LightenScreen();
    }

    void Awake() {
       if (Timer.win && MazeMinigame < 3) {
        MazeMinigame++;
        Debug.Log("Temu Hearts increased");
        Timer.win = false;
       }
       else if (GameManager.win && RhythymMinigame < 3) {
        RhythymMinigame++;
        Debug.Log("Snake Hearts increased");
        GameManager.win = false;
       }
       else if (FishingMiniGame.win && FishingMinigame < 3) {
        FishingMinigame++;
        Debug.Log("Octopus Hearts increased");
        FishingMiniGame.win = false;
       }

        // update to check score of EACH minigame
        if (MazeMinigame == 3 || RhythymMinigame == 3 || FishingMinigame == 3) {
            closedDoor.SetActive(false);
            closedDoor.GetComponent<BoxCollider2D>().enabled = false;
            openDoor.SetActive(true);
            // if (MazeMinigame == 3) LastLove.partnerName = "Temu The Gunt";
            // if (RhythymMinigame == 3) LastLove.partnerName = "Sid the Snake With No Arms";
            // if (FishingMinigame == 3) LastLove.partnerName = "Sexy Octopus";
            
        }
    }
}
