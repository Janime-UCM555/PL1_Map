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
    //Instancia de la bala
    public void Shoot()
    {


        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Vector3 directionToPlayer = (_targetTransform.position - transform.position).normalized;
        //if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))



            bullet.GetComponent<ProjectileComponent>().Setup(directionToPlayer);
        //Destroy(bullet, 5f);


    }


    public void EnemyDies()
    {
        Destroy(gameObject);
    }
    public void OnColisionEnter2D(Collider2D collider2D)
    {

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


        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(_myTransform.position, _targetTransform.position);

        // Si la distancia es menor o igual a la distancia de parada, procede a cargar para disparar una bala
        if (distanceToPlayer <= stopDistance)
        {
            if (reloadBullet >= shootTime)
            {
                _leeverMovement.StopToShoot();
            }
            else { _leeverMovement.NotStopToShoot(); }
            reloadBullet -= Time.deltaTime;
            //Si la recarga se ha completado, dispara
            if (reloadBullet <= 0.0f)
            {

                Shoot();
                reloadBullet = 2.0f;
            }
        }
        else
        {
            _leeverMovement.NotStopToShoot();
        }

    }
}