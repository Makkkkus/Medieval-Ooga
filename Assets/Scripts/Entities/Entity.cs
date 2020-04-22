﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int age { get; protected set; }
    protected int maxAge = 10;

    // How long it takes for entities to age in seconds.
    private int ageTime = 30;

    private void Start()
    {
        age = Random.Range(0, Mathf.RoundToInt(maxAge / 5));
    }

    private float secondsSinceLastAge;
    private void Update()
    {
        secondsSinceLastAge += Time.deltaTime;

        if (secondsSinceLastAge >= ageTime)
        {
            secondsSinceLastAge = 0;
            age++;
            if (age > maxAge)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
