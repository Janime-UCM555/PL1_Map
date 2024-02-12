using UnityEngine;
using UnityEngine.Tilemaps;

public class SwordProjectileComponent : MonoBehaviour
{
    private Vector3 _shotMovement;
    [SerializeField] private float _shotSpeed;
    private Rigidbody2D _myRigidBody;
    public bool SwordProjectileCollision = false;
    private Animator _animator;

    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    public void Setup(Vector3 Movement) 
    {
        _shotMovement = Movement;
    }

    private void FixedUpdate()
    {
        _myRigidBody.velocity = _shotMovement * _shotSpeed;
        if (Mathf.Approximately(_myRigidBody.velocity.magnitude, 0.0f)) _animator.SetBool("SwordProjectileCollision", true); ;
    }
    private void DestroySword()
    {

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() != null || collision.gameObject.GetComponent<TecktiteAttack>() || collision.gameObject.GetComponent<LeeverAttack>() || collision.gameObject.GetComponent<MoblinAttack>() || collision.gameObject.GetComponent<OcktorokMovement>() != null || collision.gameObject.GetComponent<CameraTrigger>() != null)
        {
            _shotMovement = Vector3.zero;
            _animator.SetBool("SwordProjectileCollision", true);
        }
        else { _animator.SetBool("SwordProjectileCollision", false); }
    }
}
