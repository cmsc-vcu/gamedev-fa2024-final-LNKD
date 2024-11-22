using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrder : MonoBehaviour
{
    public int newOrder = 1;
    public int oldOrder = 3;
    public SpriteRenderer renderer1;
    public SpriteRenderer renderer2;
    public SpriteRenderer renderer3;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (renderer1 != null) renderer1.sortingOrder = newOrder;
            if (renderer2 != null) renderer2.sortingOrder = newOrder;
            if (renderer3 != null) renderer3.sortingOrder = newOrder;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            if (renderer1 != null) renderer1.sortingOrder = oldOrder;
            if (renderer2 != null) renderer2.sortingOrder = oldOrder;
            if (renderer3 != null) renderer3.sortingOrder = oldOrder;
        }
    }
    
    
}
