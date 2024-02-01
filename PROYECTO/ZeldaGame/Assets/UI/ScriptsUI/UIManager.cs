using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int totalRupias;
    [SerializeField] private TMP_Text textoRupias;
    private  CoinComponent coinComponent;
    private void Start()
    {
        CoinComponent.sumaRupia += SumarRupias;
    }
    
    private void SumarRupias(int rupias)
    {
        totalRupias += rupias;
        textoRupias.text= totalRupias.ToString();
    }
}
