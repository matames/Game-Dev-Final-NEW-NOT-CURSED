using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typewriter : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;  // clears then= string of what to be shown

        float t = 0;
        int charIndex = 0;

        // executes each character of the string after a certain amount of time between the last character
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;

        }

        textLabel.text = textToType;
    }
}
