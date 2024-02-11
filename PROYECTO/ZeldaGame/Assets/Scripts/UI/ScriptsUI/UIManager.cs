using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static private UIManager _UIManager;
    static public UIManager UIMan { get { return _UIManager; } }
    public int totalRupias;
    public int totalBombas = 0;
    [SerializeField] private GameObject spriteBomba;
    [SerializeField] private GameObject spriteEscudo;
    [SerializeField] private GameObject spriteFlecha;
    [SerializeField] private GameObject spriteEspada;
    [SerializeField] private TMP_Text textoRupias;
    [SerializeField] private TMP_Text textoBombas;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonVacio;
    [SerializeField] private Sprite corazonMedio;

    private void Awake()
    {
        _UIManager = GetComponent<UIManager>();
    }
    private void Start()
    {
        CoinComponent.sumaRupia += SumarRupias;
        ShopItemComponent.restaRupia += RestarRupias;
        ShopItemComponent.sumaBomba += SumarBombas;
        LinkMovement.restaBomba += RestarBombas;

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
    public void SumarBombas(int bombas)
    {
        totalBombas += bombas;
        textoBombas.text = "X" + totalBombas.ToString();
    }
    public void RestarBombas(int bombas) 
    { 
        totalBombas -= bombas;
        textoBombas.text = "X" + totalBombas.ToString();
    }
    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonVacio;

    }
    public void PonerSprite(int newState)
    {
       switch (newState)
        {
            case 0:
            spriteBomba.SetActive(true);
            break;
            case 1:
            //spriteFlecha.SetActive(true);
            break;
            case 2:
            Debug.Log("No hay objeto que poner");
            break;
        }
    }
    public void PonerEspada(bool newState)
    {
        spriteEspada.SetActive(newState);
    }

}
