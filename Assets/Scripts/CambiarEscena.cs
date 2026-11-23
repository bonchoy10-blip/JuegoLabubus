
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private bool cambiandoEscena = false;

    void Update()
    {
        // Detectar cualquier tecla o botón del mouse
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if (!cambiandoEscena)
            {
                cambiandoEscena = true;

                SceneManager.LoadScene("pantalla_inicio");
            }
        }
    }
}
