using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    private Transform _myTransform;
    public GameObject itemDrop;

    public void EnemyKill(int dropType)
    {
        itemDrop.GetComponent<ItemDrop>().Drop(dropType, transform);
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        _myTransform = transform;
    }
}
