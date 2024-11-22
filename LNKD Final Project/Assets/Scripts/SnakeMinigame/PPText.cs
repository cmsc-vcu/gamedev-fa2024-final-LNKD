using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PPText : MonoBehaviour
{
    public new string name;

    // Update is called once per frame
    void Update()
    {
       GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(name)+"";
    }
}
