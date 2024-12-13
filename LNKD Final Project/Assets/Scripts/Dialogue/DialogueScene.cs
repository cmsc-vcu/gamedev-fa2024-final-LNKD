using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScene : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject textDialogue;
    [SerializeField] private GameObject dialogueBox;
    private TypewriterEffect typewriterEffect;
    public static bool played = false;
    public GameObject player = null;

    void Awake() {
        for (int i = 0; i < 1; i++) {
            played = false;
        }
    }

    private void Start(){
        if(!played){
            typewriterEffect = GetComponent<TypewriterEffect>();
            CloseDialogueBox();
            ShowDialogue(textDialogue);
        }else{
            CloseDialogueBox();
            player.GetComponent<PlayerController2D>().enabled = true;
        }
    }

    public void ShowDialogue(DialogueObject dialogueObject){
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        foreach(string dialogue in dialogueObject.Dialogue){
            yield return typewriterEffect.Run(dialogue,textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0));
        }
        CloseDialogueBox();
        player.GetComponent<PlayerController2D>().enabled = true;
    }

    private void CloseDialogueBox(){
        dialogueBox.SetActive(false);
        played = true;
        textLabel.text = string.Empty;
    }
}
