
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiarEscenaMenu : MonoBehaviour
{
    public CanvasGroup panelFade;
    public float duracionFade = 0.8f;

    private bool cambiandoEscena = false;

    public void IrAJuego()
    {
        MusicaPersistente musica = FindFirstObjectByType<MusicaPersistente>();

        if (musica != null)
        {
            musica.ReproducirMusicaJuego();
        }

        CambiarEscena("Juego");
    }

    public void IrAjustes()
    {
        CambiarEscena("Pantalla_opciones");
    }

    public void IrACreditos()
    {
        CambiarEscena("pantalla_creditos");
    }

    void CambiarEscena(string nombreEscena)
    {
        if (!cambiandoEscena)
        {
            StartCoroutine(FadeYCambiar(nombreEscena));
        }
    }

    IEnumerator FadeYCambiar(string nombreEscena)
    {
        cambiandoEscena = true;

        float tiempo = 0;

        panelFade.blocksRaycasts = true;

        while (tiempo < duracionFade)
        {
            tiempo += Time.unscaledDeltaTime;

            panelFade.alpha = Mathf.Lerp(
                0f, 1f, tiempo / duracionFade
            );

            yield return null;
        }

        panelFade.alpha = 1f;

        SceneManager.LoadScene(nombreEscena);
    }
}
