using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider ball;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimeStart(5));
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == ball)
        {
            Toggle();
        }
    }

    public void Set(bool active)
    {
        state = SwitchState.On;
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimeStart(5));
        }
    }

   private void Toggle()
    {
        if(state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.3f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.3f);
        }
        state = SwitchState.Off;
    }
    private IEnumerator BlinkTimeStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
