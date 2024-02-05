using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public int totalRupias;
    [SerializeField] private GameObject spriteBomba;
    [SerializeField] private TMP_Text textoRupias;
    [SerializeField] private TMP_Text textoPrecio;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonVacio;
    [SerializeField] private Sprite corazonMedio;
    private CoinComponent coinComponent;

    private void Start()
    {
        CoinComponent.sumaRupia += SumarRupias;
        ShopItemComponent.restaRupia += RestarRupias;

    }

    public void SumarRupias(int rupias)
    {
        totalRupias += rupias;
        textoRupias.text = "X" + totalRupias.ToString();
    }
    public void RestarRupias(int rupias)
    {
        totalRupias -= rupias;
        textoRupias.text = "X" + totalRupias.ToString();
    }
    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonVacio;

    }
    public void QuitarTexto()
    {

        Destroy(textoPrecio);
    }
    public void PonerSpriteBomba(int newState)
    {
       switch (newState)
        {
            case 0:
            spriteBomba.SetActive(true);
            break;
            case 1:
            spriteFlecha.SetActive(true);
            break;
            case 2:
            Debug.Log("No hay objeto que poner");
            break;
        }
    }

}
