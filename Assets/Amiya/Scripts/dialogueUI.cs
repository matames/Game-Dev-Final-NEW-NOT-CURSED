using System.Collections;
using UnityEngine;
using TMPro;

public class dialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private dialogueObject testDialogue;

    public bool isOpen { get; private set; }

    public bool dialogueOn;

    //private responseHandler ResponseHandler;
    private typewriter typewriterEffect;

    // Start is called before the first frame update
    private void Start()
    {
        typewriterEffect = GetComponent<typewriter>();
        //ResponseHandler = GetComponent<responseHandler>();

        CloseDialogue();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(dialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        dialogueOn = true;
        StartCoroutine(StepThroughDialogue(dialogueObject));    // coroutine for going through the dialogue
    }

    private IEnumerator StepThroughDialogue(dialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1) //&& dialogueObject.HasResponses)
            {
                break;
            }

            // allows the dialogue to slowly present itself to the player
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  // dialogue continues when space is pressed
        }
        /*
        if (dialogueObject.HasResponses)
        {
            ResponseHandler.ShowResponse(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
        }*/


    }

    private void CloseDialogue()
    {
        isOpen = false;

        dialogueBox.SetActive(false);
        dialogueOn = false;
        textLabel.text = string.Empty;
    }
}
