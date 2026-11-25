

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiarEscena : MonoBehaviour
{
    public CanvasGroup panelFade;
    public float duracionFade = 0.8f;

    private bool cambiandoEscena = false;

    void Update()
    {
        if (Input.anyKeyDown ||
            Input.GetMouseButtonDown(0) ||
            Input.GetMouseButtonDown(1) ||
            Input.GetMouseButtonDown(2))
        {
            if (!cambiandoEscena)
            {
                StartCoroutine(FadeYCambiarEscena());
            }
        }
    }

    IEnumerator FadeYCambiarEscena()
    {
        cambiandoEscena = true;

        float tiempo = 0;

        while (tiempo < duracionFade)
        {
            tiempo += Time.unscaledDeltaTime;

            panelFade.alpha = Mathf.Lerp(
                0f, 1f, tiempo / duracionFade
            );

            yield return null;
        }

        panelFade.alpha = 1f;

        SceneManager.LoadScene("pantalla_inicio");
    }
}
