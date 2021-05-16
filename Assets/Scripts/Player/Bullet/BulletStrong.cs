using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStrong : AbstractBullet
{
    void Start()
    {
        body = GetComponent<Transform>();
        speed = 0.1f;
    }
}
