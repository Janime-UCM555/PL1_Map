using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemDrop : MonoBehaviour
{
    #region refernces
    private Transform _myTransform;
    [SerializeField]
    private GameObject rupeePrefab;
    [SerializeField]
    private GameObject heartPrefab;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private GameObject fairyPrefab;
    [SerializeField]
    private GameObject clockPrefab;
    [SerializeField]
    private GameObject rupeex5Prefab;
    #endregion

    #region parameters
    // 0 = Rupee  1 = Heart  2 = Bomb  3 = Fairy  4 = Clock  5 = 5 Rupees
    private int DropRateA = 31;
    private int[] DropsA = { 1, 0, 1, 0, 3, 0, 1, 1, 0, 0 };

    private int DropRateB = 41;
    private int[] DropsB = { 1, 2, 0, 4, 0, 1, 2, 0, 2, 1 };

    private int DropRateC = 59;
    private int[] DropsC = { 5, 0, 1, 0, 5, 1, 4, 0, 0, 0 };

    private int DropRateD = 31;
    private int[] DropsD = { 1, 1, 3, 0, 1, 3, 1, 1, 1, 0 };

    private int DropRate;
    [SerializeField]
    private int killCount = 0;
    #endregion
    
    
    public void Drop(int EnemyType, Transform EnemyTransform)// El enemy type viene dado del script del enemigo
    {
        killCount++;
        _myTransform = EnemyTransform;
        DropRate = Random.Range(0, 100);
        switch (EnemyType)
        {
            case 0:
                if (DropRate < DropRateA)
                {
                    int n = killCount % 10;
                    int DropType = DropsA[n];
                    DropItem(DropType, EnemyTransform);
                }
                break;

            case 1:
                if (DropRate < DropRateB)
                {
                    int n = killCount % 10;
                    int DropType = DropsB[n];
                    DropItem(DropType, EnemyTransform);
                }
                break;

            case 2:
                if (DropRate < DropRateC)
                {
                    int n = killCount % 10;
                    int DropType = DropsC[n];
                    DropItem(DropType, EnemyTransform);
                }
                break;

            case 3:
                if (DropRate < DropRateD)
                {
                    int n = killCount % 10;
                    int DropType = DropsD[n];
                    DropItem(DropType, EnemyTransform);
                }
                break;

            case 4:
                break;
        }
    }

    public void DropItem(int DropType, Transform EnemyTransform)
    {
        switch (DropType)
        {
            case 0:
                GameObject rupee = Instantiate(rupeePrefab, EnemyTransform.transform.position, Quaternion.identity);
                break;

            case 1:
                GameObject heart = Instantiate(heartPrefab, EnemyTransform.transform.position, Quaternion.identity);
                break;

            case 2:
                GameObject bomb = Instantiate(bombPrefab, EnemyTransform.transform.position, Quaternion.identity);
                break;

            case 3:
                //GameObject fairy = Instantiate(fairyPrefab, EnemyTransform.transform.position, Quaternion.identity);
                break;

            case 4:
                GameObject clock = Instantiate(clockPrefab, EnemyTransform.transform.position, Quaternion.identity);
                break;

            case 5: 
                GameObject rupeex5 = Instantiate(rupeex5Prefab, EnemyTransform.transform.position, Quaternion.identity);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}