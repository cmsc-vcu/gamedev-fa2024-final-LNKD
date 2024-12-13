using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject Dialogue1;
    [SerializeField] private DialogueObject Dialogue2;
    [SerializeField] private DialogueObject Dialogue3;
    private DialogueObject textDialogue;
    [SerializeField] private GameObject dialogueBox;
    Scene scene;

    public GameObject player = null;

    private TypewriterEffect typewriterEffect;

    void Awake(){
        scene = SceneManager.GetActiveScene();
        if(scene.name == "MazeMinigame"){
            if(GameHandler.MazeMinigame == 0){
                textDialogue = Dialogue1;
            }else if(GameHandler.MazeMinigame == 1){
                textDialogue = Dialogue2;
            }else{
                textDialogue = Dialogue3;
            }
        }else if(scene.name == "SnakeMinigame"){
            if(GameHandler.RhythymMinigame == 0){
                textDialogue = Dialogue1;
            }else if(GameHandler.RhythymMinigame == 1){
                textDialogue = Dialogue2;
            }else{
                textDialogue = Dialogue3;
            }
        }else if(scene.name == "OctopusMinigame"){
            if(GameHandler.FishingMinigame == 0){
                textDialogue = Dialogue1;
            }else if(GameHandler.FishingMinigame == 1){
                textDialogue = Dialogue2;
            }else{
                textDialogue = Dialogue3;
            }
        }
    }

    private void Start(){
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(textDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject){
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        foreach(string dialogue in dialogueObject.Dialogue){
            yield return typewriterEffect.Run(dialogue,textLabel);
            yield return new WaitForSeconds(3f);
        }

        CloseDialogueBox();
        if (player != null) {player.GetComponent<PlayerController2D>().enabled = true;}
        if (Timer.FindObjectOfType<Timer>() != null) {Timer.start = true;}
        if (FishingMiniGame.FindAnyObjectByType<FishingMiniGame>() != null) {FishingMiniGame.pause = false;}

    }

    private void CloseDialogueBox(){
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
