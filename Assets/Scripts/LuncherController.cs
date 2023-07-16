using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuncherController : MonoBehaviour
{
    public Collider ball;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public bool isHold = false;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == ball)
        {
            ReadInput(ball);
        }
    }

    private void ReadInput(Collider collider)
    {
        if(Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(ball));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0f;
        float timeHold = 0.0f;
        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
            Debug.Log(force);
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * (-force));
        isHold = false;
    }
}
