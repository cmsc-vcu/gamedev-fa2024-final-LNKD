using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastLove : MonoBehaviour
{
    public TMP_Text text;
    public static string partnerName;

    void Awake(){
        if(partnerName == null){
            partnerName = "the host";
        }
    }

    void Update(){
        text.SetText("You fell in love with "+partnerName.ToString());
    }
}
