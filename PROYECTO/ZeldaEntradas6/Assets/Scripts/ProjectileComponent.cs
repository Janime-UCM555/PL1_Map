using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProjectileComponent : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speedValue = 10.0f;
    #endregion

    #region references
    private Transform _myTransform;

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
    }

    public void AddSpeed(Vector3 speedToAdd)
    {
        _speed = (_speed + speedToAdd).normalized * _speedValue;
    }

    public void Setup(Vector2 direction)
    {
        _speed = new Vector3(direction.x, direction.y, 0).normalized * _speedValue;
    }
    #endregion

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        _myTransform.position = _myTransform.position + _speed * Time.deltaTime;
    }


}