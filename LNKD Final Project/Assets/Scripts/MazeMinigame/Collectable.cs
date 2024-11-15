using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    I made it abstract incase I wanted to make different types of collectables
    for the scene
**/
public abstract class Collectable : MonoBehaviour
{
    public abstract void ONCollect();

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            ONCollect();
            Destroy(gameObject);
        }
    }
}
