using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame : MonoBehaviour
{
    [Header("Scenes")]
    public string miniGameScene;

    [Header("Game Status")]
    public bool won;

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            if(Timer.win){
                SceneManager.LoadScene(miniGameScene);
            }else if(!Timer.win){
                Debug.Log("Lost game, can not redo");
            }
        }
    }
}
