using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastLove : MonoBehaviour
{
    public TMP_Text text;
    public static string partnerName;
    [SerializeField] private GameObject temu;
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject octopus;

    void Awake(){
        if(partnerName == null){
            partnerName = "No one";
        }

        if(partnerName == "Temu The Gunt"){
            temu.SetActive(true);
        }else if(partnerName == "Sid the Snake With No Arms"){
            snake.SetActive(true);
        }else if(partnerName == "Cuntapus"){
            octopus.SetActive(true);
        }
    }

    void Update(){
        text.SetText("You fell in love with "+partnerName.ToString());
    }
}
