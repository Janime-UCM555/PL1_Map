using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ArrowProjectileComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speedValue = 10.0f;
    #endregion

    #region references
    private Transform _myTransform;
    private Quaternion _initialRotation; // Variable para almacenar la rotación inicial

    #endregion

    #region properties
    private Vector3 _speed;
    public Vector3 Speed
    {
        get { return _speed; }
    }
    #endregion

    #region methods
    public void SetDirection(Vector3 newDirection)
    {
        _speed = newDirection.normalized * _speedValue;
        // Rotar la flecha hacia la dirección del movimiento
        RotateArrow();
    }

    public void AddSpeed(Vector3 speedToAdd)
    {
        _speed = (_speed + speedToAdd).normalized * _speedValue;
        // Rotar la flecha hacia la dirección del movimiento
        RotateArrow();
    }

    public void Setup(Vector3 direction4Axes)
    {
        _speed = direction4Axes.normalized * _speedValue;

        // Calculamos la rotación basada en la dirección de la flecha
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction4Axes);
        _myTransform.rotation = lookRotation;
    }

    private void RotateArrow()
    {
        if (_myTransform != null && _speed != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, _speed);
            _myTransform.rotation = lookRotation;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.GetComponent<TilemapCollider2D>() != null) { Destroy(gameObject); }
        if (collider2D.gameObject.GetComponent<CameraTrigger>() != null) { Destroy(gameObject); }
        else if (collider2D.gameObject.GetComponent<LinkHealth>() != null) { Destroy(gameObject); collider2D.gameObject.GetComponent<LinkHealth>().TakesDamage(); }
    }
    #endregion

    void Awake()
    {
        _myTransform = transform;
        _initialRotation = _myTransform.rotation;
    }


    void Update()
    {
        _myTransform.position += new Vector3(_speed.x, _speed.y, 0) * Time.deltaTime;
        Destroy(this.gameObject, 2f);
    }
}