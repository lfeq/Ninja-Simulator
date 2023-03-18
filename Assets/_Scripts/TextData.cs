using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TextData")]
public class TextData : ScriptableObject
{
    public string saludo;
    public string instrucciones;

    public string[] textosMotivacionales;
    public string[] textosRegaño;

    [TextArea(3, 2)]
    public string despedida;

    public string GetRandomCongratulationText()
    {
        return textosMotivacionales[Random.Range(0, textosMotivacionales.Length)];
    }
}
