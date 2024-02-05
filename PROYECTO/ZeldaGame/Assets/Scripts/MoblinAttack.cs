using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoblinAttack : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject bulletPrefab;
    private Transform _myTransform;
    [SerializeField]
    private MoblinMovement _moblinMovement;
    [SerializeField]
    private Transform _targetTransform;
    #endregion   
    [SerializeField]
    private float daño = 1;
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
        Vector3 directionToPlayer = (_targetTransform.position - transform.position).normalized;
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            directionToPlayer.y = 0f;
        }
        else
        {
            directionToPlayer.x = 0f;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AttackComponent>() != null)
        {
            if (imune > 0)
            {
                vida -= daño;
                if (vida <= 0)
                {
                    GetComponent<ItemDrop>().Drop(droptType);
                    Destroy(gameObject);
                }
                else { imune -= 1 * Time.deltaTime; }
            }

        }
        imune = 1;

    }
    #endregion
    void Start()
    {
        _myTransform = transform;
        _moblinMovement = GetComponent<MoblinMovement>();
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
            else { _moblinMovement.NotStopToShoot(); }
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
            _moblinMovement.NotStopToShoot();
        }
    }
}