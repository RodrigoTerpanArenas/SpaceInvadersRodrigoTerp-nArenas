using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Este código va a ser el encargado de transicionar entre escenas. Por lo que va a pertenecer a un objeto que va a persistir entre escenas.

public class ManagerScript : MonoBehaviour
{
    public static int state;
    public static ManagerScript Instance;
    public static string indentificador = "";
    public static float maxX, minX, maxY;
    private Camera cam;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        cam = Camera.main;
        maxX = cam.ViewportToWorldPoint(new Vector2(1, 0)).x;
        minX = cam.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxY = cam.ViewportToWorldPoint(new Vector2(1, 1)).y;
    }

    private void Start()
    {
        if(state == 0)
        {
            state = 1;
        }
    }

    //Para cargar el nivel con lo que se necesita.
    public static void LoadGame()
    {
        SceneManager.LoadScene("Game");   
    }

    //Para regresar al inicio
    public static void LoadStart()
    {
        state = 1;
        indentificador = "";
        SceneManager.LoadScene("Start");
    }

}
