using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Hits")]
    [SerializeField] private int hitsToEndTutorial;
    private int currentHits = 0;

    [Header("Sensei Data")]
    [SerializeField] private TMP_Text senseiText;
    [SerializeField] private AudioSource senseiAudioSource;
    [SerializeField] private TextData textData;
    [SerializeField] private float showTextDurationInSeconds = 2;

    private void Start()
    {
        StartCoroutine(StartTutorial());
    }

    public void AddHit()
    {
        currentHits++;

        if (currentHits >= hitsToEndTutorial)
            EndTutorial();
    }

    IEnumerator StartTutorial()
    {
        senseiAudioSource.Play();
        yield return StartCoroutine(ShowText(textData.saludo));
        yield return StartCoroutine(ShowText(textData.instrucciones));
        senseiAudioSource.Stop();
    }

    private void EndTutorial()
    {
        //Codigo para terminar el tutorial
    }

    IEnumerator ShowText(string text)
    {
        senseiText.text = text;
        yield return new WaitForSeconds(showTextDurationInSeconds);
    }
}
