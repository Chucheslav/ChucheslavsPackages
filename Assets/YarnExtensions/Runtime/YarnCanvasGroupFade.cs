using System.Collections;
using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Canvas Group Fade")]
[RequireComponent(typeof(CanvasGroup))]
public class YarnCanvasGroupFade : MonoBehaviour
{
    [SerializeField][Min(0)] private float fadeDuration = 1f;
    
    private CanvasGroup _fadeEffect;

    private void Awake()
    {
        _fadeEffect = GetComponent<CanvasGroup>();
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (!dialogueRunner)
        {
            Debug.LogError("DialogueRunner not found");
            return;
        }
        
        dialogueRunner.AddCommandHandler("fadeIn" , FadeIn);
        dialogueRunner.AddCommandHandler("fadeOut" , FadeOut);
    }

    private Coroutine FadeIn()
    {
        return StartCoroutine(Fade(0, 1));
    }

    private Coroutine FadeOut()
    {
        return StartCoroutine(Fade(1, 0));
    }

    private IEnumerator Fade(float from, float to)
    {
        _fadeEffect.alpha = from;
        
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            _fadeEffect.alpha = Mathf.Lerp(from, to, elapsedTime / fadeDuration);
            yield return null;
        }
    }
}
}