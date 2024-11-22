using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    [Header("UI Systems")]
    public Canvas canvas;

    void Start () {
        canvas.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            canvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            canvas.enabled = false;
        }
    }
}
