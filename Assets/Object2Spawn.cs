using System.Collections.Generic;
using UnityEngine;

public class Object2Spawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects = 10;
    public float spawnRadius = 5f;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            spawnedPositions.Add(randomPosition);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        bool isValidPosition = false;

        while (!isValidPosition)
        {
            randomPosition = Random.insideUnitSphere * spawnRadius + transform.position;
            randomPosition.y = 0f; 

           
            isValidPosition = true;
            foreach (Vector3 pos in spawnedPositions)
            {
                if (Vector3.Distance(randomPosition, pos) < objectToSpawn.transform.localScale.magnitude)
                {
                    isValidPosition = false;
                    break;
                }
            }
        }

        return randomPosition;
    }
}