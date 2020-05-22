using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnHuman();
            SpawnTree();
        }
    }

    [SerializeField] private GameObject TreePrefab;
    [SerializeField] private GameObject HumanPrefab;
    [SerializeField] private static int SpawnAmount = 100;
    [SerializeField] private static int SpawnRadius = 50;

    private int i = 0;
    private void SpawnTree()
    {
        // Scatters trees around inside a certain radius.
        // TODO: Implement a better method of spawing trees.
        if (i < SpawnAmount)
        {
            Vector3 spawnPos = new Vector3(Random.insideUnitCircle.x * SpawnRadius, 0, Random.insideUnitCircle.y * SpawnRadius);

            // Check if we're overlapping with any other objects.
            Collider[] colliders = Physics.OverlapSphere(spawnPos, 10f);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Ground"))
                {
                    Instantiate(TreePrefab, spawnPos, Quaternion.Euler(0, Random.Range(0, 360), 0));
                    i++;
                    break;
                }
            }
        }
    }

    private void SpawnHuman()
    {

    }
}