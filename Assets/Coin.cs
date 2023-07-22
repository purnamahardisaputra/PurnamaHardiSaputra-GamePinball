using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    private float timeSpawn = 10f;
    private bool isBallTouching = false;


    private void Awake()
    {
        Ball = GameObject.Find("Ball");

    }

    void Update()
    {
        if (!isBallTouching)
        {
            StartCoroutine(DestroyAfterDelay(timeSpawn));
        }

        transform.Rotate(new Vector3(0, 0, 45) * (Time.deltaTime * 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Ball)
        {
            isBallTouching = true;
            Destroy(this.gameObject);
            GameManager.instance.CoinScore += addCoinScore();
        }
    }

    private IEnumerator DestroyAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (!isBallTouching)
        {
            Destroy(this.gameObject);
        }
    }

    public int addCoinScore()
    {
        return + 1;
    }
}
