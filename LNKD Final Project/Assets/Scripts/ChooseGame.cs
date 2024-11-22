using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame : MonoBehaviour
{

    [Header("Game Status")]
    // change this variable to the build settings order number
    public int GameState = 0;
    public bool won;
    public ScreenDarkener ScreenDarkener;

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            StartCoroutine(FadeWithDelay());
        }
    }

    private IEnumerator FadeWithDelay() {
        ScreenDarkener.DarkenScreen();
        yield return new WaitForSeconds(1.5f);

        if (GameState == 1 && GameHandler.MazeMinigame < 3) SceneManager.LoadScene(GameState);
        else if (GameState == 2 && GameHandler.RhythumMinigame < 3) SceneManager.LoadScene(GameState);
        else if (GameState == 3 && GameHandler.FishingMinigame < 3) SceneManager.LoadScene(GameState);
        
        else if (GameState == 5) {
            SceneManager.LoadScene(GameState);
            // QuitGame();
            
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