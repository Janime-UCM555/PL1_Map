using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region parameters
    private int Hearts = 3;
    #endregion

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
