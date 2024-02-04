using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OcktorokMovement : MonoBehaviour
{
    public Transform m_transform;
    public float _movementspeed = 5;
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

    private bool isWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 1.0f, colision) != null) return false;
        else return true;
    }


    public void Comportamientoenemigo()
    {

        float gradoactual = 0;

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {

            case 1:
                gradoactual = grado;
                grado = Random.Range(0, 4);
               
                rutina++;
                break;
            case 2:
                
                while (grado == gradoactual) grado = Random.Range(0, 4);
                switch (grado)
                {

                    case 0:

                        _movementdirection = new Vector3(-1, 0, 0) * _movementspeed * Time.deltaTime;
                        break;

                    case 1:

                        _movementdirection = new Vector3(0, 1, 0) * _movementspeed * Time.deltaTime;
                        break;
                    case 2:

                        _movementdirection = new Vector3(0, -1, 0) * _movementspeed * Time.deltaTime;
                        break;
                    case 3:

                        _movementdirection = new Vector3(1, 0, 0) * _movementspeed * Time.deltaTime;
                        break;


                }
                if (isWalkable(_movementdirection + m_transform.position)) m_transform.Translate(_movementdirection);
                break;



        }
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

