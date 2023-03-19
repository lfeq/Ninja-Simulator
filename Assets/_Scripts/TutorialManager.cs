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
    private bool isShowingText = false;

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
        yield return StartCoroutine(ShowText(textData.saludo));
        yield return StartCoroutine(ShowText(textData.instrucciones));
    }

    public void CongratulationText()
    {
        StartCoroutine(ShowCongratulationText(textData.GetRandomCongratulationText()));
    }

    public void ShameText()
    {
        StartCoroutine(ShowCongratulationText(textData.GetRandomShameText()));
    }

    public void EndTutorialText()
    {
        StartCoroutine(ShowEndTutorialText(textData.despedida));
    }

    private IEnumerator ShowEndTutorialText(string text)
    {
        yield return StartCoroutine(ShowText(text));
        player.position = newPlayerPosition.position;
    }

    private IEnumerator ShowCongratulationText(string text)
    {
        yield return ShowText(text);
    }

    private void StartShowingText()
    {
        if(!isShowingText)
        {
            senseiTextBubble.SetActive(true);
            SenseiAnimationManager.OnStartTalking.Invoke();
            senseiAudioSource.Play();
        }     
    }

    private void StopShowingText()
    {
        senseiAudioSource.Stop();
        SenseiAnimationManager.OnStopTalking.Invoke();
        senseiTextBubble.SetActive(false);
        isShowingText = false;
    }

    private void EndTutorial()
    {
        StopAllCoroutines();
        StopShowingText();
        endTutorial.Invoke();
    }

    IEnumerator ShowText(string text)
    {
        StartShowingText();
        if(!isShowingText)
        {
            isShowingText = true;
            yield return writerEffect.TypeText(senseiText, text, typeEffectSpeed);
            yield return new WaitForSeconds(showTextDurationInSeconds);
            StopShowingText();
        }
    }
}
