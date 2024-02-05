using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemComponent : MonoBehaviour
{
    public delegate void RestaRupia(int rupia);
    public static event RestaRupia restaRupia;
    [SerializeField] public int precio;
    [SerializeField] private GameObject _shopItem;
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
                    _uiManager.QuitarTexto();
                    _uiManager.PonerSpriteBomba(true);
                }
            }
        }
        
        
    }
    private void RestaRupias()
    {
        restaRupia(precio);
    }
}
