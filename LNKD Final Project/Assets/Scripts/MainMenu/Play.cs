using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;
    public void changeScenes(){
        SceneManager.LoadScene(1);
    }
}
