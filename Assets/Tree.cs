using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int age;
    private int SecondsToAge = 10;

    private void Start()
    {
        age = Random.Range(0, 4);
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