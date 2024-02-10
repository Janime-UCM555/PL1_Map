using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ZoraComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject bulletPrefab;
    private Transform _myTransform;
    [SerializeField]
    private Transform _targetTransform;
    #endregion

    private Vector3 Distance;
    
    public float distancia;
    public bool activo = false;

    #region parameters
    [SerializeField]
    private float spawnDistance = 8.0f;
    [SerializeField]
    private float ActivationDistance = 8.0f;
    [SerializeField]
    private float numBullets = 3;
    [SerializeField]
    private float reloadBullet = 3.0f;
    [SerializeField]
    private float CountdownTimer = 2.0f;
    #endregion

    public float Dispara = 0;

    #region methods
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Vector3 directionToPlayer = (_targetTransform.position - transform.position).normalized;
        bullet.GetComponent<ProjectileComponent>().Setup(directionToPlayer);
    }


    public void EnemyDissapears()
    {
        Destroy(gameObject);
    }


    #endregion
    void Start()
    {
        _myTransform = transform;
        _targetTransform = LinkMovement.Link.GetComponent<Transform>();
        
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }

    void Update()
    {
        Distance = _targetTransform.position - _myTransform.position;
        distancia = Distance.magnitude;

        if (distancia <= spawnDistance)
        {
            GetComponent<Renderer>().enabled = true;

            if (distancia <= ActivationDistance)
            {
                activo = true;
            }

            if (activo)
            {
                if (Dispara < numBullets)
                {
                    reloadBullet -= Time.deltaTime;
                    if (reloadBullet <= 0.0f)
                    {
                        Shoot();
                        Dispara++;
                        reloadBullet = 3.0f;
                    }
                }
                else
                {
                    CountdownTimer -= Time.deltaTime;
                    if (CountdownTimer <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }


    }
}
