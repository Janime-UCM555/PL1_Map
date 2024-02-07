using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
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

    #region parameters
    [SerializeField]
    private float stopDistance = 4.0f;
    [SerializeField]
    private float reloadBullet = 2.0f;
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

    public void OnTriggerEnter()
    {
        //Collider para el ataque del jugador contra el enemigo
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
            _ocktorokMovement.StopToShoot();
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
