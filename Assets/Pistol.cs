using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject gun;
    public GameObject flash;
    public AudioSource gunfire;
    public bool isShot = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& !isShot)
        {
            StartCoroutine(Firing());
        }

        IEnumerator Firing()
        {
            isShot = true;
            gun.GetComponent<Animation>().Play("shot");

            //strzelanie z broni
            //flash.GetComponent<Animation>().Play("flash");
            //flash.SetActive(true);

            gunfire.Play();
            yield return new WaitForSeconds(0.5f);
            isShot = false;
        }
    }
}
