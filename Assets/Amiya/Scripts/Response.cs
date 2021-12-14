using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private dialogueObject DialogueObject;
    // response element
    public string ResponseText => responseText;

    public dialogueObject dialogueObject => DialogueObject;
}
