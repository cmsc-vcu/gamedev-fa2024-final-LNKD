using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
