using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public MinimapController minimapController;
    private Vector2 direccionPasada;

    private void OnTriggerEnter2D(Collider2D other)
    {
        LinkMovement link = other.gameObject.GetComponent<LinkMovement>();
        if (link != null && minimapController != null)
        {
            Vector2 direccionMirada = link.direccionMirada;

            if (direccionMirada != Vector2.zero)
            {
                GameManager.Game.MoveCamera();
                minimapController.ActualizarDireccion(direccionMirada);
            }
        }
    }

    public Vector2 GetDireccionPasada()
    {
        return direccionPasada;
    }



    // Start is called before the first frame update
    void Start()
    {
        minimapController = FindObjectOfType<MinimapController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
