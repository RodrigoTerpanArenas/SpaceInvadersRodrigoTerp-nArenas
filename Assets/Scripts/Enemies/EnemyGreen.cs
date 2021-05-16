using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : AbstractEnemy
{
    public Sprite[] listGreen = new Sprite[2];
    public GameObject[] listUpGreen = new GameObject[3];


    //Variables del enemigo azul (el de en medio)
    private void Start()
    {
        alternateSprite = listGreen[0];
        defeatedSprite = listGreen[1];
        UpD = listUpGreen[0];
        UpB = listUpGreen[1];
        UpR = listUpGreen[2];
        enemyHealth = 1;
        enemyPoint = 1;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
   
}

