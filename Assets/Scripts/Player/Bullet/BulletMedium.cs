using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMedium : AbstractBullet
{
    void Start()
    {
        body = GetComponent<Transform>();
        speed = 0.5f;
    }
}
