using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;
    [SerializeField] Transform fish;
    
    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] public float timerMultiplier = 3f; 

    float fishspeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] public float hookSize = 0.1f;
    [SerializeField] public float hookPower = 0.5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] public float hookPullPower = 0.01f;
    [SerializeField] public float hookGravityPower = 0.005f;
    [SerializeField] public float hookProgressDegradtionPower = 0.1f;
    [SerializeField] KeyCode myKeyCode = KeyCode.Space;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBarContainer;

    bool pause = false;

    [SerializeField] float failTimer = 10f;

    public static bool win = false;

    private void Start(){
        Resize();
    }

    private void Resize(){
        Bounds b = hookSpriteRenderer.bounds;
        float ysize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position,bottomPivot.position);
        ls.y = (distance/ysize*hookSize);
        hook.localScale = ls;
    }

    private void Update(){
        if(pause){
            return;
        }
        Fish();
        Hook();
        ProgressCheck();
    }

    private void ProgressCheck(){
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize /2;
        float max = hookPosition + hookSize /2;

        if(min < fishPosition && fishPosition < max){
            hookProgress += hookPower * Time.deltaTime;
        }else{
            hookProgress -= hookProgressDegradtionPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if(failTimer < 0f){
                Lose();
            }
        }

        if(hookProgress >= 1f){
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Win(){
        pause = true;
        win = true;
        Debug.Log("Wig has been retreived, congrats");
        SceneManager.LoadScene(4);
    }

    private void Lose(){
        pause = true;
        Debug.Log("The wig has been lost to the sea, you lose");
        SceneManager.LoadScene(4);
    }

    void Hook(){
        if(Input.GetKey(myKeyCode)){
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize/2 <= 0f && hookPullVelocity < 0f){
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize/2 >= 1f && hookPullVelocity > 0f){
            hookPullVelocity = 0f;
        }
        hookPosition = Mathf.Clamp(hookPosition,0,1);
        hook.position = Vector3.Lerp(bottomPivot.position,topPivot.position,hookPosition);
    }

    void Fish(){
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0f){
            fishTimer = UnityEngine.Random.value * timerMultiplier;
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition,fishDestination,ref fishspeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position,topPivot.position,fishPosition);
    }
}
