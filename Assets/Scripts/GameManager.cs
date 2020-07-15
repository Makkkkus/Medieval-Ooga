using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Random.InitState(0);
        SpawnTree();
    }

    public GameObject TreePrefab;
    public GameObject HumanPrefab;
    [SerializeField] private static short SpawnRadius = 100;

    private void SpawnTree()
    {
        for (int x = 0; x <= SpawnRadius; x += 3)
        {
            for (int y = 0; y <= SpawnRadius; y += 3)
            {
                if (Random.value < 0.5f)
                {
                    Instantiate(TreePrefab, new Vector3(x - SpawnRadius / 2, 0, y - SpawnRadius / 2), Quaternion.Euler(0, Random.Range(0, 90), 0));
                }
            }
        }
    }
}