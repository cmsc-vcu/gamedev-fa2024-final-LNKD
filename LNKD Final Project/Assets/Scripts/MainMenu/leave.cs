using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave : MonoBehaviour
{
    [SerializeField] GameObject current;
    [SerializeField] GameObject play;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            current.SetActive(false);
        }
    }

    public void ToggleBoolean()
    {
        if (current.activeSelf) {
            current.SetActive(false);
            play.SetActive(true);
        }
        else if (!current.activeSelf) {
            current.SetActive(true);
            play.SetActive(false);
        }
    }
}