using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpersController : MonoBehaviour
{
    public Collider ball;
    public float multiplier;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        // ganti warna ketika awal start game menjadi merah
        renderer.material.color = Color.red;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == ball)
        {
            Rigidbody ballRig = ball.GetComponent<Rigidbody>();
            ballRig.velocity *= multiplier;

            animator.SetTrigger("BumperHit");

            // rubah warna dari merah menjadi biru, biru menjadi hijau, hijau menjadi merah
            if (renderer.material.color == Color.red)
            {
                renderer.material.color = Color.blue;
            }
            else if (renderer.material.color == Color.blue)
            {
                renderer.material.color = Color.green;
            }
            else if (renderer.material.color == Color.green)
            {
                renderer.material.color = Color.red;
            }
        }
    }
}
