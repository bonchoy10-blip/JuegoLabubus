
using UnityEngine;

public class ControladorLanzamiento : MonoBehaviour
{
    [Header("Referencias")]
    public Rigidbody proyectil;
    public Transform puntoLanzamiento;
    public LineRenderer lineaTrayectoria;

    [Header("Configuracion")]
    public float fuerzaMaxima = 60f;
    public float distanciaMaxima = 2f;
    public float longitudLinea = 3f;
    public float gravedadPersonalizada = 20f;

    private Camera camara;
    private Vector3 posicionInicial;
    private bool apuntando = false;
    private bool lanzado = false;

    void Start()
    {
        camara = Camera.main;
        posicionInicial = puntoLanzamiento.position;

        PrepararProyectil();

        if (lineaTrayectoria != null)
        {
            lineaTrayectoria.enabled = false;
            lineaTrayectoria.positionCount = 2;
        }
    }

    void Update()
    {
        if (lanzado)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            apuntando = true;
        }

        if (apuntando && Input.GetMouseButton(0))
        {
            Apuntar();
        }

        if (apuntando && Input.GetMouseButtonUp(0))
        {
            Lanzar();
        }
    }

    void FixedUpdate()
    {
        if (!lanzado)
            return;

        proyectil.AddForce(
            Vector3.down * gravedadPersonalizada,
            ForceMode.Acceleration
        );
    }

    void PrepararProyectil()
    {
        proyectil.transform.position = posicionInicial;
        proyectil.useGravity = false;
        proyectil.isKinematic = true;
    }

    void Apuntar()
    {
        Vector3 posicionMouse = Input.mousePosition;

        posicionMouse.z = Mathf.Abs(
            camara.transform.position.z - posicionInicial.z
        );

        Vector3 posicionMundo =
            camara.ScreenToWorldPoint(posicionMouse);

        Vector3 direccion = posicionInicial - posicionMundo;

        direccion.z = 0f;

        direccion = Vector3.ClampMagnitude(
            direccion,
            distanciaMaxima
        );

        proyectil.transform.position =
            posicionInicial - direccion;

        if (lineaTrayectoria != null)
        {
            lineaTrayectoria.enabled = true;

            Vector3 direccionLanzamiento = direccion.normalized;

            lineaTrayectoria.SetPosition(
                0, posicionInicial
            );

            lineaTrayectoria.SetPosition(
                1,
                posicionInicial +
                direccionLanzamiento * longitudLinea
            );
        }
    }

    void Lanzar()
    {
        apuntando = false;
        lanzado = true;

        if (lineaTrayectoria != null)
        {
            lineaTrayectoria.enabled = false;
        }

        Vector3 direccion =
            posicionInicial - proyectil.transform.position;

        direccion.z = 0f;

        float distancia = direccion.magnitude;

        float fuerza = Mathf.Clamp(
            distancia / distanciaMaxima,
            0f,
            1f
        ) * fuerzaMaxima;

        fuerza *= 4f;

        proyectil.isKinematic = false;
        proyectil.useGravity = false;

        proyectil.AddForce(
            direccion.normalized * fuerza,
            ForceMode.Impulse
        );
    }
}
