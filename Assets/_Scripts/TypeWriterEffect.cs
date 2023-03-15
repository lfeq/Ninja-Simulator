using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect
{
    public IEnumerator TypeText(TMP_Text canvasText, string text, float speedInSeconds)
    {
        canvasText.text = string.Empty;
        int characterIndex = 0;

        while(characterIndex < text.Length)
        {
            canvasText.text += text[characterIndex];
            characterIndex++;
            yield return new WaitForSeconds(speedInSeconds);
        }

        canvasText.text = text;
    }
}
