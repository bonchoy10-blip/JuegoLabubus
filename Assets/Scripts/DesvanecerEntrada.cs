
using UnityEngine;
using System.Collections;

public class DesvanecerEntrada : MonoBehaviour
{
    public CanvasGroup panelFade;
    public float duracionFade = 0.8f;

    void Start()
    {
        StartCoroutine(FadeEntrada());
    }

    IEnumerator FadeEntrada()
    {
        float tiempo = 0;

        while (tiempo < duracionFade)
        {
            tiempo += Time.unscaledDeltaTime;

            panelFade.alpha = Mathf.Lerp(
                1f, 0f, tiempo / duracionFade
            );

            yield return null;
        }

        panelFade.alpha = 0f;
    }
}
