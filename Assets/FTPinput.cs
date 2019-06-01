using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FTPinput : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 50.0f;
    public float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip footStep;
    private bool isStep = false;

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaY = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        if(!isStep&&(deltaX>0|| deltaY>0))
        {
            StartCoroutine(Step());
        }

        IEnumerator Step()
        {
            isStep = true;
            soundSource.PlayOneShot(footStep);
            yield return new WaitForSeconds(0.5f);
            isStep = false;
        }
    }
}
