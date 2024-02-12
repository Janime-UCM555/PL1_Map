

using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LeeverMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 3;
    public float _minimalDistance = 10.0f;
    public Vector3 _movementdirection;

    public float cronometro;
    public float grado;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private LayerMask colision;
    [SerializeField]
    private LayerMask bounds;
    private Vector3 directionToPlayer;
    [SerializeField] private Transform _targetTransform;
    //private Animator _myAnimator;
    bool activo;

    private bool _stopToShoot = false;

    public void StopToShoot()
    {
        _stopToShoot = true;
        _movementspeed = 0;

    }

    public void NotStopToShoot()
    {
        _stopToShoot = false;
        _movementspeed = 5;
    }

    private bool isWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 1f, colision | bounds) != null) return false;
        return true;
    }


    public void Comportamientoenemigo()
    {
        Vector3 movement;
        // Calcula la dirección en el eje X hacia el jugador
            float directionX = Mathf.Sign(_targetTransform.position.x - transform.position.x);
            movement = new Vector3(directionX, 0, 0) * _movementspeed * Time.deltaTime;
            if (isWalkable(transform.position + movement)) transform.position += movement;

    }
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancetoPlayer = Vector3.Distance(_targetTransform.position,m_transform.position);
        float distancex = _targetTransform.position.x - m_transform.position.x;
        if (distancetoPlayer < _minimalDistance && Math.Abs(distancex) > 0.2f)
        {
            Comportamientoenemigo();

        }

    }
}