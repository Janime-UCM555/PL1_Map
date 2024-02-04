using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class OcktorokAttack : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject bulletPrefab;
    private Transform _myTransform;
    [SerializeField]
    private OcktorokMovement _ocktorokMovement;
    [SerializeField]
    private Transform _targetTransform;
    #endregion   
    [SerializeField]
    private float da�o = 1;
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
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
        {
            directionToPlayer.y = 0f;
        }
        else
        {
            directionToPlayer.x = 0f;
        }


        bullet.GetComponent<ProjectileComponent>().Setup(directionToPlayer);

        Destroy(bullet, 5f);

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<AttackComponent>() != null)
        {
            if (imune > 0)
            {
                vida--;
                if (vida <= 0)
                {
                    Destroy(this, 3f);
                    GetComponent<ItemDrop>().Drop(droptType);
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
        _ocktorokMovement = GetComponent<OcktorokMovement>();
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
                _ocktorokMovement.StopToShoot();
            }
            else { _ocktorokMovement.NotStopToShoot(); }
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
            _ocktorokMovement.NotStopToShoot();
        }
    }
}