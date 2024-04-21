using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float intervaloDeSpawn = 1f;
    public float minX = -5f; 
    public float maxX = 5f; 

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, intervaloDeSpawn);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
