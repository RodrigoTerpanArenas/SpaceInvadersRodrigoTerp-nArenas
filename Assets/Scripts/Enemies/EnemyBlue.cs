using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : AbstractEnemy
{
    public Sprite[] listBlue = new Sprite[2];
    public GameObject[] listUpBlue = new GameObject[3];

    //Variables del enemigo azul (el de en medio)
    private void Start()
    {
        alternateSprite = listBlue[0];
        defeatedSprite = listBlue[1];
        UpD = listUpBlue[0];
        UpB = listUpBlue[1];
        UpR = listUpBlue[2];
        enemyHealth = 2;
        enemyPoint = 2;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
