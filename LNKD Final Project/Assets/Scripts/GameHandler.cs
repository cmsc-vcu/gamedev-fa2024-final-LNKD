using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // current love score with temu
    public static int MazeMinigame = 0;
    public static int RhythumMinigame = 0;
    public static int FishingMinigame = 0;

    [Header("Game Systems")]
    public GameObject closedDoor;
    public GameObject openDoor;
    public Canvas panner;
    public ScreenDarkener ScreenDarkener;

    private bool winstopper = false;


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
       else if (GameManager.win && RhythumMinigame < 3) {
        RhythumMinigame++;
        Debug.Log("Snake Hearts increased");
        GameManager.win = false;
       }
       else if (winstopper && FishingMinigame < 3) {
        FishingMinigame++;
        Debug.Log("Octopus Hearts increased");
       }

        // update to check score of EACH minigame
        if (MazeMinigame == 3 || RhythumMinigame == 3 || FishingMinigame == 3) {
            closedDoor.SetActive(false);
            closedDoor.GetComponent<BoxCollider2D>().enabled = false;
            openDoor.SetActive(true);
            if (MazeMinigame == 3) LastLove.partnerName = "Temu The Gunt";
            if (RhythumMinigame == 3) LastLove.partnerName = "Snake With No Arms";
            if (FishingMinigame == 3) LastLove.partnerName = "Sexy Octopus";
            
        }
    }
}
