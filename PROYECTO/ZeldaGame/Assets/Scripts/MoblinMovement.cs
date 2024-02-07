using UnityEngine;

public class MoblinMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 3;
    public Vector3 _movementdirection;
    public int rutina;
    public float cronometro;
    public float grado;
    [SerializeField]
    private LayerMask colision;

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
    private bool isWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 1.0f, colision) != null) return false;
        else return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientoenemigo();
    }
}
