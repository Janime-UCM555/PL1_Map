using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemComponent : MonoBehaviour
{
    public delegate void RestaRupia(int rupia);
    public static event RestaRupia restaRupia;
    [SerializeField] private bool shopeable;
    [SerializeField] private int precio;
    [SerializeField] public int identificadorTienda;
    [SerializeField] private TMP_Text textoPrecio;
    private UIManager _uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        LinkMovement player = collision.gameObject.GetComponent<LinkMovement>();
        if (player != null)
        {
            if (_uiManager.totalRupias >= precio && shopeable)
            {
                if (restaRupia != null)
                {
                    RestaRupias();
                    _uiManager.SumarBombas(1);
                    Destroy(this.gameObject);
                    Destroy(textoPrecio);
                    _uiManager.PonerSprite(identificadorTienda);
                }
            }
            else
            {
                Destroy(this.gameObject); _uiManager.PonerSprite(identificadorTienda);
            }
        }
    }
    private void RestaRupias()
    {
        restaRupia(precio);
    }
    void Start()
    {
        _uiManager = UIManager.UIMan;   
    }
}
