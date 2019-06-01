using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject gate;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Open());
        StartCoroutine(Close());
    }

    IEnumerator Open()
    {
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 actual = gate.transform.position;

            gate.transform.position = new Vector3(actual.x+i,actual.y,actual.z);
        }
    }

    IEnumerator Close()
    {
        for(int i=0;i<5; i++)
        {
            yield return new WaitForSeconds(0.8f);
            Vector3 actual = gate.transform.position;

            gate.transform.position = new Vector3(actual.x - i, actual.y, actual.z);
        }
    }
}
