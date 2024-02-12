using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject SalaEspada;
    [SerializeField] private GameObject SalaTienda;
    [SerializeField] private GameObject SalaSecreta;

    private int Hearts;
    static private GameManager _game;
    static public GameManager Game
    {
        get { return _game; }
    }

    [SerializeField]
    private CameraMovement _camera;

    public void MoveCamera()
    {
        _camera.Move();
    }
    public void EnterRoom()
    {
        LinkMovement.Link.Enter();
        _camera.Enter();
    }
    public void ActivateRoom(bool espada, bool tienda, bool secreto)
    {
        SalaEspada.SetActive(espada);
        SalaTienda.SetActive(tienda);
        SalaSecreta.SetActive(secreto);
    }
    public void ExitRoom()
    {
        LinkMovement.Link.Exit();
        _camera.Exit();
    }
    public void Damage()
    {
        //Decremento de la cantidad de corazones por hit
        Hearts--;
        Debug.Log("Te quedan " +  Hearts + " corazones!");
        if (Hearts == 0)
        {
            EndGame();
            //Metodo EndGame
        }
    }
    public void EndGame()
    {
        LoadScene();
        //metodo loadScene
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Reinicio de escena, en este caso seria el caso de muerte
    }
    void Awake()
    {
        _game = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateRoom(false, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
