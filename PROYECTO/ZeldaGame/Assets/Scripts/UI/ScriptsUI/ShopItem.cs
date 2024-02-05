using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemComponent : MonoBehaviour
{
    public delegate void RestaRupia(int rupia);
    public static event RestaRupia restaRupia;
    [SerializeField] private int precio;
    [SerializeField] public int identificadorTienda;
    [SerializeField] private TMP_Text textoPrecio;
    public UIManager _uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        LinkMovement player = collision.gameObject.GetComponent<LinkMovement>();
        if (player != null)
        {          
            if(_uiManager.totalRupias >= precio)
            {
                if (restaRupia != null)
                {
                    RestaRupias();
                    Destroy(this.gameObject);
                    Destroy(textoPrecio); 
                    _uiManager.PonerSprite(identificadorTienda);
                }
            }
        }  
    }
    private void RestaRupias()
    {
        restaRupia(precio);
    }
}
