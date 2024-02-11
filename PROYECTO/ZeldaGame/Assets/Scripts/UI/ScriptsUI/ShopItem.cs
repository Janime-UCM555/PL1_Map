using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemComponent : MonoBehaviour
{
    public delegate void RestaRupia(int rupia);
    public static event RestaRupia restaRupia;
    public delegate void SumaBomba(int bomba);
    public static event SumaBomba sumaBomba;

    private int cantdadBombas = 1;
    public LinkMovement _bomb;
    [SerializeField] private int precio;
    [SerializeField] public int identificadorTienda;
    [SerializeField] private TMP_Text textoPrecio;
    private UIManager _uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        LinkMovement player = collision.gameObject.GetComponent<LinkMovement>();
        if (player != null)
        {
            if (_uiManager.totalRupias >= precio)
            {
                if (restaRupia != null)
                {
                    RestaRupias();
                    SumarBomba();
                    Destroy(this.gameObject);
                    Destroy(textoPrecio);
                    _uiManager.PonerSprite(identificadorTienda);
                    _bomb.CanPlaceBomb(true);
                }
            }
        }
    }
    private void RestaRupias()
    {
        restaRupia(precio);
    }
    private void SumarBomba()
    {
       sumaBomba(cantdadBombas);
    }
    void Start()
    {
        _uiManager = UIManager.UIMan;   
    }
}
