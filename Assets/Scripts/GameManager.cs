using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 5; i++)
            SpawnTree();
    }

    public GameObject Tree;
    private static int SpawnAmount = 100;
    [SerializeField] private int SpawnRadius = 50;

    private int i = 0;
    private void SpawnTree()
    {
        // Scatters trees around inside a certain radius
        if (i < SpawnAmount)
        {
            Vector3 spawnPos = new Vector3(Random.insideUnitCircle.x * SpawnRadius, 0, Random.insideUnitCircle.y * SpawnRadius);
            Collider[] colliders = Physics.OverlapSphere(spawnPos, 10f);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Ground"))
                {
                    Instantiate(Tree, spawnPos, Quaternion.Euler(0, Random.Range(0, 360), 0));
                    i++;
                    break;
                }
            }
        }
    }
}