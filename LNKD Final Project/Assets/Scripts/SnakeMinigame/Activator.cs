using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note,gm;
    Sprite old;
    [SerializeField] Sprite newSprite;
    public bool createMode;
    public GameObject n;

    void Awake(){
        gm = GameObject.Find("GameManager");
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        old = sr.sprite;
        PlayerPrefs.SetInt("Score",0000);
    }

    void Update()
    {
        if(createMode){
            if(Input.GetKeyDown(key)){
                Instantiate(n,transform.position,Quaternion.identity);
            }
        }else{
            if(Input.GetKeyDown(key)){
                StartCoroutine(IsPressed());
            }
            if(Input.GetKeyDown(key) && active){
                Destroy(note);
                gm.GetComponent<GameManager>().AddStreak();
                AddScore();
                active = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        active = true;
        if(col.gameObject.tag == "Note"){
            note = col.gameObject;
        }
    }

    void AddScore(){
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+gm.GetComponent<GameManager>().GetScore());
    }

    IEnumerator IsPressed(){
        sr.sprite = newSprite;
        yield return new WaitForSeconds(0.1f);
        sr.sprite = old;
    }
}
