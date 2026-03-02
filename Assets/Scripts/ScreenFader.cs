using System.Threading.Tasks;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ScreenFader Instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDur = 0.5f;

    private void Awake()
    {
        if (Instance == null) Instance=this;
        else Destroy(gameObject);
    }


    async Task Fade(float targetTransp)
    {
        float start = canvasGroup.alpha, t = 0;
        while (t < fadeDur)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, targetTransp, t / fadeDur);
            await Task.Yield();
        }

        canvasGroup.alpha = targetTransp;
    }

    public async Task FadeOut()
    {
        await Fade(1); // fade to black
    }

    public async Task FadeIn()
    {
        await Fade(0); // Fade to transparent.
    }
}
