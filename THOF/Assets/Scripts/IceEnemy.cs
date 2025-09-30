using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceEnemy : MonoBehaviour
{
    public bool isFightable = true;

    public int health = 22;
    public int speed = 6;
    public int strenght = 4;

    BoxCollider2D BC2;

    Stats St;

    // Start is called before the first frame update
    void Start()
    {
        St = GameObject.Find("Player").GetComponent<Stats>();
        BC2 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WhatAmI();
    }

    void WhatAmI()
    {
        if (isFightable == false)
        {
            Destroy(BC2);
        }
    }

}
