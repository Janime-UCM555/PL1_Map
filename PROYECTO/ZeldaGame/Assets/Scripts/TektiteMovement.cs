using UnityEngine;

public class TektiteMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 400f;
    public Vector3 _movementdirection;
    public float cronometro;
    public float grado;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private LayerMask colision;
    [SerializeField]
    private LayerMask bounds;
    [SerializeField] private Transform _targetTransform;
    [SerializeField]
    private float _distanceToPlayer = 3.0f;
    [SerializeField]
    private float _distanceToActive = 12.0f;
    [SerializeField]
    private float _maxSpeed = 400f;
    private float _currentSpeed;
    private float _chaseTimer;
    private float chaseInterval = 1f;
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
            grado = Random.Range(0, 7);
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
            else if (grado == 4)
            {
                _movementdirection = new Vector3(1, 1, 0) * _movementspeed * Time.deltaTime;
            }
            else if (grado == 5)
            {
                _movementdirection = new Vector3(-1, 1, 0) * _movementspeed * Time.deltaTime;
            }
            else if (grado == 6)
            {
                _movementdirection = new Vector3(1, -1, 0) * _movementspeed * Time.deltaTime;
            }
            else if (grado == 7)
            {
                _movementdirection = new Vector3(-1, -1, 0) * _movementspeed * Time.deltaTime;
            }
            m_transform.Translate(_movementdirection);

        }




    }

    private void GoToPlayer(float distanceToPlayer)
    {
        _chaseTimer += Time.deltaTime;

        // Solo persigue al jugador si el temporizador alcanza el intervalo deseado
        if (_chaseTimer >= chaseInterval)
        {
            Vector3 directionToPlayer = (_targetTransform.position - transform.position).normalized;

            // Calcula la dirección del movimiento solo en 4 ejes
            Vector3 movementDirection = new Vector3(Mathf.Round(directionToPlayer.x), Mathf.Round(directionToPlayer.y), 0f);

            // Calcula la velocidad actual del enemigo basada en la distancia al jugador
            _currentSpeed = Mathf.Lerp(0, _maxSpeed, distanceToPlayer / _distanceToPlayer);

            // Comprueba si hay obstáculos en la dirección hacia el jugador
            if (isWalkable(m_transform.position + movementDirection * _currentSpeed * Time.deltaTime))
            {
                // Mueve al enemigo en la dirección hacia el jugador
                m_transform.Translate(movementDirection * _currentSpeed * Time.deltaTime);
            }

            // Flip sprite horizontalmente si el jugador está a la izquierda
            _spriteRenderer.flipX = movementDirection.x < 0;

            // Reinicia el temporizador
            _chaseTimer = 0f;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _targetTransform.position);

        if (distanceToPlayer <= _distanceToPlayer)
        {
            // El jugador está dentro de la distancia de persecución, así que el enemigo lo persigue
            GoToPlayer(distanceToPlayer);
        }
        else if (distanceToPlayer < _distanceToActive)
        {
            Comportamientoenemigo();
            _movementspeed = 500f;
        }
        
    }
}

