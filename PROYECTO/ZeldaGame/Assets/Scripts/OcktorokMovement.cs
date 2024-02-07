using UnityEngine;

public class OcktorokMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 5;
    public Vector3 _movementdirection;
    public float cronometro;
    public float grado;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private LayerMask colision;
    [SerializeField]
    private LayerMask bounds;
    private ShootingComponent _shooting;
    private Vector3 directionToPlayer;
    [SerializeField] private Transform _targetTransform;
    private Animator _myAnimator;

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
        if (Physics2D.OverlapCircle(targetPosition, 0.7f, colision | bounds) != null) return false;
        return true;
    }


    public void Comportamientoenemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 1.5)
        {
            cronometro = 0;
            grado = Random.Range(0, 4);
        }
        else
        {
            if (grado == 0)
            {
                _movementdirection = new Vector3(-1, 0, 0) * _movementspeed * Time.deltaTime;
            }

            else if (grado == 1)
            {
                _movementdirection = new Vector3(0, 1, 0) * _movementspeed * Time.deltaTime;
            }
            else if (grado == 2)
            {
                _movementdirection = new Vector3(0, -1, 0) * _movementspeed * Time.deltaTime;
            }
            else if (grado == 3)
            {
                _movementdirection = new Vector3(1, 0, 0) * _movementspeed * Time.deltaTime;
            }
            if (isWalkable(_movementdirection + m_transform.position)) m_transform.Translate(_movementdirection);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shooting = GetComponent<ShootingComponent>();
        _myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        directionToPlayer = (_targetTransform.position - transform.position).normalized;
        Comportamientoenemigo();
        if (directionToPlayer.y > 0)
        {
            _spriteRenderer.flipY = true;
            _myAnimator.SetBool("Lateral", false);
        }
        else if (directionToPlayer.y == 0 || directionToPlayer.y < 0)
        {
            _spriteRenderer.flipY = false;
            _myAnimator.SetBool("Lateral", false);
        }
        if (directionToPlayer.x > 0)
        {
            _myAnimator.SetBool("Lateral", true);
            _spriteRenderer.flipX = true;
        }
        else if (directionToPlayer.x < 0)
        {
            _myAnimator.SetBool("Lateral", true);
            _spriteRenderer.flipX = false;

        }

    }
}

