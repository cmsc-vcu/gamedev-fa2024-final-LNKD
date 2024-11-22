using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public int scene;
    void OnEnable(){
        SceneManager.LoadScene(scene,LoadSceneMode.Single);
    }
}
