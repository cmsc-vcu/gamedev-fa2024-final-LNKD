using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollectable : Collectable
{
    public string newScene;
    public override void ONCollect()
    {
        Timer.win = true;
        SceneManager.LoadScene(newScene); //load hub scene if collected
    }
}
