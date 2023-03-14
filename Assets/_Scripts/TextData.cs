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
}
