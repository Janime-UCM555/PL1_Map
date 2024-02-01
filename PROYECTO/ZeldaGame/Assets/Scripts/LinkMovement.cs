using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class LinkMovement : MonoBehaviour
{
    private Vector3 room = new Vector3(-27, -6, 0);
    private float _xvalue;
    private float _yvalue;
    public Vector3 _directionVector;
    public Vector3 _movementVector;
    public float SpeedValue = 2f;
    private Rigidbody2D _myRigidBody;
    private Transform _myTransform;

    [SerializeField] private AttackComponent _attackComponent;
    [SerializeField] private Collider2D _swordCollider;
    [SerializeField] private SpriteRenderer _swordSprite;

    static private LinkMovement _movement;
    static public LinkMovement Link { get { return _movement; } }
    public void RegisterX(float x)
    {
        _xvalue = x;
    }

    public void RegisterY(float y)
    {
        _yvalue = y;
    }
    public void Enter()
    {
        _myTransform.position = room;
    }
    public void Exit()
    {
        _myTransform.position = EnterTrigger.lastPosition;
    }
    public void StopWhileAttack()
    {
        _movement.enabled = false;
        _myRigidBody.velocity = Vector3.zero;
        _attackComponent.SummonSword();

        GetComponent<ItemDrop>().Drop(0);
        //Lo he puesto aqui para probar. Despues hay que poner esto en un enemy script con una variable serialize field para poder indicar el tipo de enemigo en unity
    }

    public void AttackEnds()
    {
        this.enabled = true;
        _swordCollider.enabled = false;
        _swordSprite.enabled = false;
    }
    void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        if (_movement == null) _movement = this;
        else Destroy(_movement);
    }
    private void Start()
    {
        _myTransform = transform;
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(_xvalue) > Mathf.Abs(_yvalue))
        {
            _yvalue = 0;
        }
        else
        {
            _xvalue = 0;
        }
        _directionVector = new Vector3(_xvalue, _yvalue);
        _movementVector = SpeedValue * _directionVector;
        _myRigidBody.velocity = _movementVector;
    }
}
