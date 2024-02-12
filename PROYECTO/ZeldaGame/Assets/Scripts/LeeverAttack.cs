using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class LeeverAttack : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject bulletPrefab;
    private Transform _myTransform;
    [SerializeField]
    private LeeverMovement _leeverMovement;


    private Transform _targetTransform;
    #endregion   
    [SerializeField]
    public float vida = 2;
    [SerializeField]
    public int droptType = 1;
    private float imune;



    #region parameters
    [SerializeField]
    private float stopDistance = 10.0f;
    [SerializeField]
    private float reloadBullet = 2.0f;
    [SerializeField]
    private float shootTime = 1.0f;
    #endregion

    #region methods
    public void EnemyDies()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<AttackComponent>() != null || collider.gameObject.GetComponent<SwordProjectileComponent>() != null || collider.gameObject.GetComponent<BombComponent>() != null)
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
        else if (collider.gameObject.GetComponent<LinkHealth>() != null)
        {
            collider.gameObject.GetComponent<LinkHealth>().TakesDamage();
        }
        imune = 1;


    }
    #endregion
    void Start()
    {
        _myTransform = transform;
        _leeverMovement = GetComponent<LeeverMovement>();
        _targetTransform = LinkMovement.Link.GetComponent<Transform>();


    }

    void Update()
    {

    }
}