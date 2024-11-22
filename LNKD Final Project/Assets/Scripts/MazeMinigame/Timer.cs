using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public float startTime = 120f;
    public static bool win = false;

    private void Start() {
        remainingTime = startTime;
        timerText.text = "02:00.00";
    }

    void Update()
    {
        if(remainingTime > 0){
            remainingTime -= Time.deltaTime;
            win = true;
        }else {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
