
using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    public Slider sliderVolumen;

    private AudioSource reproductor;

    void Start()
    {
        MusicaPersistente musica =
            FindFirstObjectByType<MusicaPersistente>();

        if (musica != null)
        {
            reproductor = musica.reproductor;

            sliderVolumen.SetValueWithoutNotify(
                reproductor.volume
            );

            sliderVolumen.onValueChanged.AddListener(
                CambiarVolumen
            );
        }
    }

    public void CambiarVolumen(float volumen)
    {
        if (reproductor != null)
        {
            reproductor.volume = volumen;
        }
    }
}
