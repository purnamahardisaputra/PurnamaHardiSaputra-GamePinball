using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform respawnPoint;
    // instance respawn controller
    RespawnController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == ball)
        {
            ball.transform.position = respawnPoint.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
