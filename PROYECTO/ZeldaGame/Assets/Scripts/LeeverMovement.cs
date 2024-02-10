

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LeeverMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 3;
    public float _minimalDistance = 5;
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
        if (Physics2D.OverlapCircle(targetPosition, 0.7f, colision | bounds) != null) return false;
        return true;
    }


    public void Comportamientoenemigo()
    {
        /*
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 1.5)
        {
            cronometro = 0;
            grado = Random.Range(0, 2);
        }
        else
        {
            if (grado == 0)
            {
                _movementdirection = new Vector3(-1, 0, 0) * _movementspeed * Time.deltaTime;
            }

            else if (grado == 1)
            {
                _movementdirection = new Vector3(1, 0, 0) * _movementspeed * Time.deltaTime;
            }

        }
        */

        // Calcula la dirección en el eje X hacia el jugador
        float directionX = Mathf.Sign(_targetTransform.position.x - transform.position.x);
        Vector3 movement = new Vector3(directionX, 0, 0) * _movementspeed * Time.deltaTime;

        transform.position += movement;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shooting = GetComponent<ShootingComponent>();
        //_myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        directionToPlayer = (_targetTransform.position - transform.position).normalized;

        float distancetoPlayer = Vector3.Distance(m_transform.position, _targetTransform.position);

        if (distancetoPlayer < _minimalDistance)
        {
            Comportamientoenemigo();
            if (directionToPlayer.y > 0)
            {
                _spriteRenderer.flipY = false;
                //_myAnimator.SetBool("Lateral", false);
            }
            else if (directionToPlayer.y == 0 || directionToPlayer.y < 0)
            {
                _spriteRenderer.flipY = false;
                //_myAnimator.SetBool("Lateral", false);
            }
            if (directionToPlayer.x > 0)
            {
                //_myAnimator.SetBool("Lateral", true);
                _spriteRenderer.flipX = true;
            }
            else if (directionToPlayer.x < 0)
            {
                //_myAnimator.SetBool("Lateral", true);
                _spriteRenderer.flipX = false;

            }
        }

    }
}