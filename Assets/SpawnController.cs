using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private float respawnRadius; // Radius respawn
    [SerializeField] private GameObject[] RespawnPrefabsPoints;
    [SerializeField] private GameObject SpawnPrefabs;
    [SerializeField] private int Count;

    private List<GameObject> usedRespawnPoints = new List<GameObject>();

    private Vector3 respawnPosition;

    private float TimeDelaySpawn = 3f;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        int respawnPointsCount = RespawnPrefabsPoints.Length;
        if (Count > respawnPointsCount)
        {
            Count = respawnPointsCount;
        }

        for (int i = 0; i < Count; i++)
        {
            int randomIndex;
            GameObject randomRespawnPoint;

            do
            {
                randomIndex = Random.Range(0, respawnPointsCount);
                randomRespawnPoint = RespawnPrefabsPoints[randomIndex];
            }
            while (usedRespawnPoints.Contains(randomRespawnPoint));

            usedRespawnPoints.Add(randomRespawnPoint);

            // Mendapatkan posisi respawn point dengan area radius pada sumbu X dan Z
            Vector2 randomCirclePoint = Random.insideUnitCircle * respawnRadius;
            respawnPosition = new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y) + randomRespawnPoint.transform.position;

            var newCoin = Instantiate(SpawnPrefabs, respawnPosition, Quaternion.Euler(90, 0, 0));
            newCoin.transform.parent = this.gameObject.transform;
            newCoin.SetActive(true);
        }
    }

    private void Update()
    {
        if (transform.childCount < 3)
        {
            TimeDelaySpawn -= Time.deltaTime;
            if (TimeDelaySpawn <= 0)
            {
                SpawnCoinSingle();
            }
        }
    }

    private void SpawnCoinSingle()
    {
        Vector2 vector2 = Random.insideUnitCircle * respawnRadius;
        respawnPosition = new Vector3(vector2.x, 0f, vector2.y) + transform.position;

        var spawnCoin = Instantiate(SpawnPrefabs, respawnPosition, Quaternion.Euler(90, 0, 0));
        spawnCoin.transform.parent = this.gameObject.transform;
        TimeDelaySpawn = 3f;
    }
}
