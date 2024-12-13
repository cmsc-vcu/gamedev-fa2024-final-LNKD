using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class Clicks : MonoBehaviour
{
    [SerializeField] private int untilTemu;
    [SerializeField] private int untilSnake;
    [SerializeField] private int untilOcto;

    [SerializeField] private GameObject Temu;
    [SerializeField] private GameObject Snake;
    [SerializeField] private GameObject Octo;

    private int click = 0;

    //Before you say it, yes this is a very dumb way to go about this. But I didn;t sleep last nigth so I'm trying my best
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)){
            click++;
        }
        if(click == untilTemu){
            Temu.SetActive(true);
        }else if(click == untilSnake){
            Temu.SetActive(false);
            Snake.SetActive(true);
        }else if(click == untilOcto){
            Snake.SetActive(false);
            Octo.SetActive(true);
        }else if(click == 32){
            SceneManager.LoadScene(5);
        }
    }
}
