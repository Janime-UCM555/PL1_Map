using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    public delegate void SumaRupia(int rupia);
    public static event SumaRupia sumaRupia;
    [SerializeField] private int cantidadRupias;
    private void OnTriggerEnter2D(Collider2D other)
    {
        LinkMovement player = other.gameObject.GetComponent<LinkMovement>();
        if(player != null) 
        {
            if (sumaRupia != null)
            {
                SumarRupia();
                Destroy(this.gameObject);
            }
        }
    }
    private void SumarRupia()
    {
        sumaRupia(cantidadRupias);
    }
    
}
