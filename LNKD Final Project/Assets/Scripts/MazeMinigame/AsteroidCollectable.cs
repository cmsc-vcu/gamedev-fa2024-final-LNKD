using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollectable : Collectable
{

    public override void ONCollect()
    {
        Timer.win = true;
        SceneManager.LoadScene(4); //load hub scene if collected
    }
}
