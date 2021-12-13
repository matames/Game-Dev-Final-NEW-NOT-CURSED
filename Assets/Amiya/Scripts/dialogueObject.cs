using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class dialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    //[SerializeField] private Response[] responses;

    public string[] Dialogue => dialogue;   // calling the dialogue i put into unity as a string

    // tells if there is a reponse or not for when to stop
    //public bool HasResponses => Responses != null && Responses.Length > 0;

    //public Response[] Responses => responses;
}
