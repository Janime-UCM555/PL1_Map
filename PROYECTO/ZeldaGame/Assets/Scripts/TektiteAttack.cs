using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TecktiteAttack : MonoBehaviour
{

    public float vida = 1;
    [SerializeField]
    public int droptType = 1;
    private float imune;
    private LinkHealth health;




    #region references
    private Transform _myTransform;

    #endregion

    public void EnemyDies()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {

        if (collider2D.gameObject.GetComponent<LinkHealth>() != null) { Destroy(gameObject); collider2D.gameObject.GetComponent<LinkHealth>().TakesDamage(); }



        if (collider2D.gameObject.GetComponent<AttackComponent>() != null || collider2D.gameObject.GetComponent<SwordProjectileComponent>() != null || collider2D.gameObject.GetComponent<BombComponent>() != null)
        {
            if (imune > 0)
            {
                vida--;
                if (vida <= 0)
                {
                    GetComponent<ItemDrop>().Drop(droptType, _myTransform);
                    EnemyDies();
                }
                else { imune -= 1 * Time.deltaTime; }
            }

        }
        imune = 1;
    }


    void Start()
    {
        _myTransform = transform;
    }



}