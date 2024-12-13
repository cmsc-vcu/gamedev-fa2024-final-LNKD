using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseGame : MonoBehaviour
{

    [Header("Game Status")]
    // change this variable to the build settings order number
    public int Game = 0;
    public bool won;
    public ScreenDarkener ScreenDarkener;


    [Header("Game Instructions")]
    public Canvas canvas;
    public GameObject instructions;

    private bool play;
    private int GameState;

    [Header("Lover Choices")]
    public int winner = 0;
    public Canvas lovers = null;
    public GameObject temu = null;
    public GameObject sid = null;
    public GameObject sexy = null;

    private void Start() {
        instructions.SetActive(false);
        winner = 0;
        canvas.enabled = false;
        if (lovers != null) {lovers.enabled = false;}
        if (temu != null) {temu.SetActive(false);}
        if (sid != null) {sid.SetActive(false);}
        if (sexy != null) {sexy.SetActive(false);}
        instructions.SetActive(false);
        play = false;
    }
    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            GameState = Game;
            StartCoroutine(FadeWithDelay());
        }
    }

    private IEnumerator FadeWithDelay() {
        ScreenDarkener.DarkenScreen();
        yield return new WaitForSeconds(1.5f);
        canvas.enabled = true;
        instructions.SetActive(true);
        play = true;
    }

    public void ChooseTemu() {
        if (GameHandler.MazeMinigame == 3) {
            winner = 1;
        }
    }
    public void ChooseSnake() {
        if (GameHandler.RhythymMinigame == 3) {
            winner = 2;
        }
    }    public void ChooseOctopus() {
        if (GameHandler.FishingMinigame == 3) {
            winner = 3;
        }
    }

    private void Update() {
        if (play) {
            if (GameState == 2 && GameHandler.MazeMinigame < 3) {
                
                instructions.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    SceneManager.LoadSceneAsync(GameState);
                }
            }
            else if (GameState == 3 && GameHandler.RhythymMinigame < 3) {
                instructions.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    SceneManager.LoadScene(GameState);
                }
            }
            else if (GameState == 4 && GameHandler.FishingMinigame < 3) {
                instructions.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space)) {
                    SceneManager.LoadScene(GameState);
                }
            } 
            
            else if (GameState == 6) {
                instructions.SetActive(false);
                canvas.enabled = false;
                lovers.enabled = true;
                if (GameHandler.MazeMinigame == 3) {temu.SetActive(true);}
                if (GameHandler.RhythymMinigame == 3) {sid.SetActive(true);}
                if (GameHandler.FishingMinigame == 3) {sexy.SetActive(true);}
                if (winner == 1) {
                    LastLove.partnerName = "Temu The Gunt";
                    Debug.Log("meow");
                    SceneManager.LoadScene(GameState);
                }
                else if (winner == 2) {
                    LastLove.partnerName = "Sid the Snake With No Arms";
                    Debug.Log("meow");
                    SceneManager.LoadScene(GameState);
                }
                else if (winner == 3) {
                    LastLove.partnerName = "Cuntapus";
                    Debug.Log("meow");
                    SceneManager.LoadScene(GameState);
        }
                // QuitGame();
                
            }
        }
    }
    private void QuitGame() {
        #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}