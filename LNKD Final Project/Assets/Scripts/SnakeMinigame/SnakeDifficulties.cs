using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDifficulties : MonoBehaviour
{
    public GameManager managing;
    public GameObject music;
    [Header("Difficulties")]
    [SerializeField] GameObject easy;
    [SerializeField] GameObject medium;
    [SerializeField] GameObject hard;

    [Header("Songs")]
    [SerializeField] AudioClip easySong;
    [SerializeField] AudioClip mediumSong;
    [SerializeField] AudioClip hardSong;

    void Awake(){

        AudioSource audioSource = music.GetComponent<AudioSource>();

        if(GameHandler.RhythymMinigame == 0){
            PlayerPrefs.SetInt("max",6700);
            medium.SetActive(false);
            hard.SetActive(false);
            easy.SetActive(true);
            audioSource.clip = easySong;
            audioSource.Play();
            Debug.Log("Rhythmn game difficulty set to 1");

        }else if(GameHandler.RhythymMinigame == 1){
            PlayerPrefs.SetInt("max",21000);
            medium.SetActive(true);
            hard.SetActive(false);
            easy.SetActive(false);
            audioSource.clip = mediumSong;
            audioSource.Play();
            Debug.Log("Rhythmn game difficulty set to 2");
        }else{
            PlayerPrefs.SetInt("max",23000);
            medium.SetActive(false);
            hard.SetActive(true);
            easy.SetActive(false);
            audioSource.clip = hardSong;
            audioSource.Play();
            Debug.Log("Rhythmn game difficulty set to 3");
        }
    }
}
