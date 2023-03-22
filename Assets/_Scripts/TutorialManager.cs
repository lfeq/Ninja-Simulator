using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Hits")]
    [SerializeField] private int hitsToEndTutorial;
    private int currentHits = 0;

    [Header("Sensei Data")]
    [SerializeField] private Transform senseiObject;
    [SerializeField] private Transform senseiNewPosition;
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
    [SerializeField] private ParticleSystem playerSmokeParticle;

    private void Start()
    {
        writerEffect= new TypeWriterEffect();
        string[] tutorialTexts = new string[2] { textData.saludo, textData.instrucciones};
        StartCoroutine(ShowText(tutorialTexts));
    }

    public void AddHit()
    {
        currentHits++;

        if (currentHits >= hitsToEndTutorial)
            EndTutorial();
    }

    public void CongratulationText()
    {
        string[] texts = new string[1] { textData.GetRandomCongratulationText() };
        StartCoroutine(ShowText(texts));
    }

    public void ShameText()
    {
        string[] texts = new string[1] { textData.GetRandomShameText() };
        StartCoroutine(ShowText(texts));
    }

    public void EndTutorialText()
    {
        string[] texts = new string[1] { textData.despedida };
        StartCoroutine(ShowText(texts, true));
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

    IEnumerator ShowText(string[] texts, bool endTutorial = false)
    {
        foreach (string text in texts)
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

        if(endTutorial)
        {
            playerSmokeParticle.Play();
            player.position = newPlayerPosition.position;
            senseiObject.position = senseiNewPosition.position;
            senseiObject.rotation = new Quaternion(0, 180, 0, 0);
            SenseiAnimationManager.OnStartPointing.Invoke();
            string[] _texts = new string[1] { textData.instruccionesJuego };
            StartCoroutine(ShowText(_texts));
        }
    }
}
