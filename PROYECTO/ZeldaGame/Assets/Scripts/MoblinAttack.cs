using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class MoblinAttack : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject bulletPrefab;
    private Transform _myTransform;
    [SerializeField]
    private MoblinMovement _moblinMovement;

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
        if (reloadBullet <= 0.0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Calculamos la dirección hacia el jugador
            Vector3 directionToPlayer = (_targetTransform.position - transform.position).normalized;

            // Aproximamos la dirección hacia el jugador en los 4 ejes
            Vector3 direction4Axes = Vector3.zero;
            if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
            {
                direction4Axes.x = Mathf.Sign(directionToPlayer.x);
            }
            else
            {
                direction4Axes.y = Mathf.Sign(directionToPlayer.y);
            }

            // Pasamos la dirección aproximada al método Setup
            bullet.GetComponent<ArrowProjectileComponent>().Setup(direction4Axes);

            reloadBullet = shootTime;
        }
    }


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
        _moblinMovement = GetComponent<MoblinMovement>();
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
                _moblinMovement.StopToShoot();
            }
            else
            {
                _moblinMovement.NotStopToShoot();
            }

            // Si la recarga se ha completado, dispara
            if (reloadBullet <= 0.0f)
            {
                Shoot();
            }
            else
            {
                reloadBullet -= Time.deltaTime; // Reduce el tiempo de recarga solo si no se ha disparado
            }
        }
        else
        {
            _moblinMovement.NotStopToShoot();
        }
    }
}