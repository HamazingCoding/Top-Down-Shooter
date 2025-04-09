using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (playerHealth.CurrentHealth <= 0f) return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        newEnemy.layer = 3;
        // Debug: Check if the spawned enemy has the right components
        Debug.Log("Spawned enemy. Layer: " + newEnemy.layer +
                  ", Has Collider: " + (newEnemy.GetComponent<Collider>() != null) +
                  ", Has EnemyHealth: " + (newEnemy.GetComponent<EnemyHealth>() != null));
    }
}
