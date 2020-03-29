using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public int age { get; private set; }

    private int SecondsToAge = 20;

    private void Start()
    {
        age = Random.Range(0, 24);
    }

    private float SecondsSinceLastAge;
    private void Update()
    {
        SecondsSinceLastAge += Time.deltaTime;

        if (SecondsSinceLastAge >= SecondsToAge)
        {
            SecondsSinceLastAge = 0;
            age++;
        }

    }
}