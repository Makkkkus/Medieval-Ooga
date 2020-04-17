using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 5; i++)
            SpawnTree();
    }

    public GameObject Tree;
    private static int SpawnAmount = 50;
    [SerializeField] private int SpawnRadius = 50;

    private int i = 0;
    private int x = -SpawnAmount;
    private int y = SpawnAmount;
    private void SpawnTree()
    {
        //* Scatters it around inside a certain radius
        if (i < SpawnAmount)
        {
            Vector3 spawnPos = new Vector3(Random.insideUnitCircle.x * SpawnRadius, 0, Random.insideUnitCircle.y * SpawnRadius);
            Collider[] colliders = Physics.OverlapSphere(spawnPos, 10f);
            foreach (Collider col in colliders)
            {
                if (!col.gameObject.CompareTag("Tree"))
            
                {
                    Instantiate(Tree, spawnPos, Quaternion.Euler(0, Random.Range(0, 360), 0));
                    i++;
                }
                Debug.Log(col.gameObject.name);
            }
        }
        //*/

        /* Alternative way (Creates a grid)
        if (x < SpawnAmount)
        {
            if (y > -SpawnAmount)
            {
                Instantiate(Tree, new Vector3(x, 0, y), Quaternion.Euler(0, Random.Range(0, 350), 0));
                y -= 4;
            } else
            {
                x += 4;
                y = SpawnAmount;
            }
        }
        //*/
    }
}