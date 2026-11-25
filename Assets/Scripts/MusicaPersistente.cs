
using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    public AudioSource reproductor;
    public AudioClip musicaMenu;
    public AudioClip musicaJuego;

    void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;

        DontDestroyOnLoad(gameObject);

        // Iniciar con la música del menú
        CambiarMusica(musicaMenu);
    }

    public void CambiarMusica(AudioClip nuevaMusica)
    {
        if (reproductor.clip == nuevaMusica)
            return;

        reproductor.clip = nuevaMusica;
        reproductor.Play();
    }

    public void ReproducirMusicaJuego()
    {
        CambiarMusica(musicaJuego);
    }
}
