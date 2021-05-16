using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : AbstractBullet
{
    void Start()
    {
        body = GetComponent<Transform>();
        speed = 0.3f;

    }

}
