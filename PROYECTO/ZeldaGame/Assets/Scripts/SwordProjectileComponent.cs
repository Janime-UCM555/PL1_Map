using UnityEngine;
using UnityEngine.Tilemaps;

public class SwordProjectileComponent : MonoBehaviour
{
    private Vector3 _shotMovement;
    [SerializeField] private float _shotSpeed;
    [SerializeField] private AttackComponent _attackComponent;
    private Rigidbody2D _myRigidBody;
    public bool SwordProjectileCollision = false;
    private Animator _animator;

    private void Awake()
    {
        _shotMovement = _attackComponent._lastMovement;
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myRigidBody.velocity = _attackComponent._lastMovement * _shotSpeed;
    }
    void Start()
    {
        
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _myRigidBody.velocity = _shotMovement * _shotSpeed;
    }
    private void DestroySword()
    {

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() != null || collision.gameObject.GetComponent<OcktorokAttack>() != null || collision.gameObject.GetComponent<CameraTrigger>() != null)
        {

            _animator.SetBool("SwordProjectileCollision", true);
            Debug.Log("colisiona");
        }
        else { _animator.SetBool("SwordProjectileCollision", false); }
    }
    void Update()
    {
        Debug.Log(_shotMovement);
        
    }

}
