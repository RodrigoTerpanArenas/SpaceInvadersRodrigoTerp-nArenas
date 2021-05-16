using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //Aqupi vamos a controlar el score del jugador.

    public static float score;
    private Text scText;

    //Variable para gameOver
    public static bool isDead;
    public static bool isWin;
    private GameObject sliderX, scoreTextGame, buttonGame, buttonRight, buttonLeft;
    private GameObject player;
    private GameObject panelFinal;
    private GameObject gameOver, sc, textWin;
    private Text puntosFin;

    

    //Inicializamos el texto del score.
    void Start()
    {
        //Iniciamos el tiempo.
        Time.timeScale = 1;
        //Inicializamos las variables y ocultamos lo que debe permanecer oculto.
        isDead = false;
        isWin = false;
        score = 0;

        scText = GameObject.Find("TextScore").GetComponent<Text> ();
        sliderX = GameObject.Find("SliderUpgrade");
        scoreTextGame = GameObject.Find("textTScore");
        buttonGame = GameObject.Find("ButtonFire");
        buttonRight = GameObject.Find("ButtonRight");
        buttonLeft = GameObject.Find("ButtonLeft");
        panelFinal = GameObject.Find("PanelFin");
        gameOver = GameObject.Find("textoGameOver");
        sc = GameObject.Find("textoScoreFinal");
        textWin = GameObject.Find("textoGanaste");
        puntosFin = sc.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");


        sliderX.SetActive(true);
        scoreTextGame.SetActive(true);
        buttonGame.SetActive(true);
        panelFinal.SetActive(false);
        player.SetActive(true);
    }

    // Se actualiza el score
    void Update()
    {
        scText.text = score.ToString();
        puntosFin.text = score.ToString();

        if (isDead == true)
        {
            Time.timeScale = 0;
            ShowResults();
        }

        if(isWin == true)
        {
            Time.timeScale = 0;
            ShowWin();
        }
    }

    private void ShowWin()
    {
        player.SetActive(false);
        sliderX.SetActive(false);
        scoreTextGame.SetActive(false);
        buttonGame.SetActive(false);
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        panelFinal.SetActive(true);
        scText.gameObject.SetActive(false);
        textWin.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        sc.gameObject.SetActive(true);
    }

    private void ShowResults()
    {
        player.SetActive(false);
        sliderX.SetActive(false);
        scoreTextGame.SetActive(false);
        buttonGame.SetActive(false);
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
        panelFinal.SetActive(true);
        scText.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        textWin.gameObject.SetActive(false);
        sc.gameObject.SetActive(true);
    }
}
