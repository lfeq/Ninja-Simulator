using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Hits")]
    [SerializeField] private int hitsToEndTutorial;
    private int currentHits = 0;

    [Header("Sensei Data")]
    [SerializeField] private TMP_Text senseiText;
    [SerializeField] private AudioSource senseiAudioSource;
    [SerializeField] private GameObject senseiTextBubble;
    [SerializeField] private TextData textData;
    [SerializeField] private float showTextDurationInSeconds = 2;
    [SerializeField] private float typeEffectSpeed = 0.3f;

    private TypeWriterEffect writerEffect;

    [Header("Comportamiento al terminar el nivel")]
    public UnityEvent endTutorial;

    [Header("Player Data")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform newPlayerPosition;

    private void Start()
    {
        writerEffect= new TypeWriterEffect();
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
        StartShowingText();

        yield return StartCoroutine(ShowText(textData.saludo));
        yield return StartCoroutine(ShowText(textData.instrucciones));

        StopShowingText();
    }

    public void CongratulationText()
    {
        StartCoroutine(ShowCongratulationText(textData.GetRandomCongratulationText()));
    }

    public void EndTutorialText()
    {
        StartCoroutine(ShowEndTutorialText(textData.despedida));
    }

    private IEnumerator ShowEndTutorialText(string text)
    {
        StartShowingText();

        yield return StartCoroutine(ShowText(text));

        StopShowingText();
    }

    private IEnumerator ShowCongratulationText(string text)
    {
        StartShowingText();

        yield return ShowText(text);
       
        StopShowingText();

        player.position = newPlayerPosition.position;
    }

    private void StartShowingText()
    {
        senseiTextBubble.SetActive(true);
        SenseiAnimationManager.OnStartTalking.Invoke();
        senseiAudioSource.Play();
    }

    private void StopShowingText()
    {
        senseiAudioSource.Stop();
        SenseiAnimationManager.OnStopTalking.Invoke();
        senseiTextBubble.SetActive(false);
    }

    private void EndTutorial()
    {
        endTutorial.Invoke();
    }

    IEnumerator ShowText(string text)
    {
        yield return writerEffect.TypeText(senseiText, text, typeEffectSpeed);
        yield return new WaitForSeconds(showTextDurationInSeconds);
    }
}
