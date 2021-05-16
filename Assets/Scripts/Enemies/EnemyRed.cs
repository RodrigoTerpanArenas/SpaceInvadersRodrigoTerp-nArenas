using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : AbstractEnemy
{
    public Sprite[] listRed = new Sprite[2];
    public GameObject[] listUpRed = new GameObject[3];


    //Variables del enemigo azul (el de en medio)
    private void Start()
    {
        alternateSprite = listRed[0];
        defeatedSprite = listRed[1];
        UpD = listUpRed[0];
        UpB = listUpRed[1];
        UpR = listUpRed[2];
        enemyHealth = 3;
        enemyPoint = 3;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
   
}

