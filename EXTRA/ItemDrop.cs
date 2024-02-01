using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // 0 = Rupee  1 = Heart  2 = Bomb  3 = Fairy  4 = Clock  5 = 5 Rupees
    private int DropRateA = 31;
    private int[] DropsA = { 1, 0, 1, 0, 3, 0, 1, 1, 0, 0 };

    private int DropRateB = 41;
    private int[] DropsB = { 1, 2, 0, 4, 0, 1, 2, 0, 2, 1 };

    private int DropRateC = 59;
    private int[] DropsC = { 5, 0, 1, 0, 5, 1, 4, 0, 0, 0 };

    private int DropRateD = 31;
    private int[] DropsD = { 1, 1, 3, 0, 1, 3, 1, 1, 1, 0 };

    private int DropRate = Random.Range(0, 100);
    private int killCount = 0;
    public void Drop(int EnemyType)// El enemy type viene dado del script del enemigo
    {
        killCount++;
        switch (EnemyType)
        {
            case 0:
                if (DropRate < DropRateA)
                {
                    int n = killCount % 10;
                    int DropType = DropsA[n];
                    DropItem(DropType);
                }
                break;

            case 1:
                if (DropRate < DropRateB)
                {
                    int n = killCount % 10;
                    int DropType = DropsB[n];
                    DropItem(DropType);
                }
                break;
            
            case 2:
                if (DropRate < DropRateC)
                {
                    int n = killCount % 10;
                    int DropType = DropsC[n];
                    DropItem(DropType);
                }
                break;

            case 3:
                if (DropRate < DropRateD)
                {
                    int n = killCount % 10;
                    int DropType = DropsD[n];
                    DropItem(DropType);
                }
                break;

            case 4:
                break;
        }

    }

    public void DropItem(int DropType)
    {
        switch (DropType)
        {
            case 0:
                //Codigo para generar los drops en el juego
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
