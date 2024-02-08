using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    public Image minimapImage;
    public float velocidadMovimiento = 10f;
    public CameraTrigger cameraTrigger;

    void Start()
    {
        cameraTrigger = FindObjectOfType<CameraTrigger>();
    }

    void Update()
    {
        Vector2 direccionPasada = cameraTrigger.GetDireccionPasada();

        Vector2 nuevaPosicion = minimapImage.rectTransform.anchoredPosition + direccionPasada * velocidadMovimiento * Time.deltaTime;
        minimapImage.rectTransform.anchoredPosition = nuevaPosicion;
    }

    public void ActualizarDireccion(Vector2 direccion)
    {
        Vector2 nuevaPosicion = minimapImage.rectTransform.anchoredPosition + direccion * velocidadMovimiento * Time.deltaTime;
        minimapImage.rectTransform.anchoredPosition = nuevaPosicion;
    }



}
