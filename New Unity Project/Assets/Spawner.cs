using UnityEngine;
using System.Collections;

/// <summary>
/// Spawns enemies at the game object called Spawner.
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public float spawnTime;
    public float spawnTimeRandom;

    /// <summary>
    /// Void Start is called before the first frame update. It calls the method ResetSpawnTimer()
    /// </summary>
    void Start()
    {
        ResetSpawnTimer();
    }

    /// <summary>
    /// Every frame void Update is called once. It subtracts the spawnTime by the passed. 
    /// If spawnTime reaches 0 one of the enemies in the array spawnObject is chosen randomly and spawned in the scene. 
    /// After spawning the enemy the method calls ResetSpawnTimer.
    /// </summary>
    void Update()
    {
        spawnTime -= Time.deltaTime;
        int spawnObjectIndex = Random.Range(0, spawnObject.Length);
        if (spawnTime <= 0.0f)
        {
            Instantiate(spawnObject[spawnObjectIndex], transform.position, Quaternion.identity);
            ResetSpawnTimer();
        }
    }

    /// <summary>
    /// Void ResetSpawnTimer restarts the spawnTime and adds a random offset within the range of 0 and spawnTimeRandom.
    /// </summary>
    void ResetSpawnTimer()
    {
        spawnTime = (float)(spawnTime + Random.Range(0, spawnTimeRandom));
    }
}