using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float respawnRadius; // Radius respawn
    [SerializeField] private GameObject[] RespawnCoinPoints;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private int CoinCount;

    private List<GameObject> usedRespawnPoints = new List<GameObject>();

    private Vector3 respawnPosition;

    private float TimeDelaySpawn = 3f;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        int respawnPointsCount = RespawnCoinPoints.Length;
        if (CoinCount > respawnPointsCount)
        {
            CoinCount = respawnPointsCount;
        }

        for (int i = 0; i < CoinCount; i++)
        {
            int randomIndex;
            GameObject randomRespawnPoint;

            do
            {
                randomIndex = Random.Range(0, respawnPointsCount);
                randomRespawnPoint = RespawnCoinPoints[randomIndex];
            }
            while (usedRespawnPoints.Contains(randomRespawnPoint));

            usedRespawnPoints.Add(randomRespawnPoint);

            // Mendapatkan posisi respawn point dengan area radius pada sumbu X dan Z
            Vector2 randomCirclePoint = Random.insideUnitCircle * respawnRadius;
            respawnPosition = new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y) + randomRespawnPoint.transform.position;

            var newCoin = Instantiate(CoinPrefab, respawnPosition, Quaternion.Euler(90, 0, 0));
            newCoin.transform.parent = this.gameObject.transform;
            newCoin.SetActive(true);
        }
    }

    private void Update()
    {
        if(transform.childCount < 3)
        {
            TimeDelaySpawn -= Time.deltaTime;
            if(TimeDelaySpawn <= 0)
            {
                SpawnCoinSingle();
            }
        }
    }

    private void SpawnCoinSingle()
    {
        Vector2 vector2 = Random.insideUnitCircle * respawnRadius;
        respawnPosition = new Vector3(vector2.x, 0f, vector2.y) + transform.position;

        var spawnCoin = Instantiate(CoinPrefab, respawnPosition, Quaternion.Euler(90, 0, 0));
        spawnCoin.transform.parent = this.gameObject.transform;
        TimeDelaySpawn = 3f;
    }
}
