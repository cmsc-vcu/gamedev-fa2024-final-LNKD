using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int multiplier = 1;
    int streak = 0;
    public static bool win = false;

    void Start()
    {
        PlayerPrefs.SetInt("score",0);
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Last"){
            Debug.Log("SCORE " + GetScore());
            Debug.Log("SCORE " + PlayerPrefs.GetInt("Score"));
            if(PlayerPrefs.GetInt("Score") <= (PlayerPrefs.GetInt("max")/2)){
                
                Debug.Log("Minigame has lost, score less than 3300");
            }else{
                win = true;
                Debug.Log("Minigame won! Score higher than 3300");
            }
            SceneManager.LoadScene(4);

        }
        if(col.gameObject.tag == "Note"){
            ResetStreak();
        }
    }

    public void AddStreak(){
        streak++;
        if(streak >= 49){
            multiplier = 4;
        }else if(streak >= 24){
            multiplier = 3;
        }else if(streak >= 12){
            multiplier = 2;
        }else{
            multiplier = 1;
        }
        UpdateGUI();
    }

    public void ResetStreak(){
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void UpdateGUI(){
        PlayerPrefs.SetInt("Streak",streak);
        PlayerPrefs.SetInt("Mult",multiplier);
    }

    public int GetScore(){
        return 100*multiplier;
    }
}
