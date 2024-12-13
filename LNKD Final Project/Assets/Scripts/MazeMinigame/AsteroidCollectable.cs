using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollectable : Collectable
{

    public override void ONCollect()
    {
        Timer.start = false;
        SceneManager.LoadScene(5); //load hub scene if collected
    }
}
