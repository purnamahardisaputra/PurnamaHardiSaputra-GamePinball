using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    private float timeSpawn = 10f;
    private bool isBallTouching = false;


    private void Awake()
    {
        Ball = GameObject.Find("Ball");
        // rotate this gameobject to fix position
        transform.Rotate(new Vector3(-90, 0, 0));
    }

    void Update()
    {
        if (!isBallTouching)
        {
            StartCoroutine(DestroyAfterDelay(timeSpawn));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Ball)
        {
            isBallTouching = true;
            Destroy(this.gameObject);
            GameManager.instance.Health += decreaseHealth();
            Ball.transform.position = RespawnController.instance.respawnPoint.position;
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

    public int decreaseHealth()
    {
        return -1;
    }
}
