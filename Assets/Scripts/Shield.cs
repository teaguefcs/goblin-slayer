﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Sword
{
    public int powerStored;
    public Light light;

    protected override void Start()
    {
        base.Start();
        selected = false;
        powerStored = 0;
    }

    protected override void Update()
    {
        base.Update();

    }

    public void IncreasePower()
    {
        powerStored++;
        light.intensity = Mathf.Min(4, powerStored);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster") && collision.gameObject.GetComponent<Limb>().myMonster.health > 0)
        {
            collision.gameObject.GetComponent<Limb>().myMonster.health -= powerStored;
            powerStored = 0;
            light.intensity = 0;
        }
    }
}
