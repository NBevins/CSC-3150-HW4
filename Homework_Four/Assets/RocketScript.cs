using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    new Rigidbody rigidbody;
    AudioSource audioSource; 
    [SerializeField] float speed = 2000f;
    [SerializeField] float roatationMultiplier = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.W)){
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * speed);
            if (!audioSource.isPlaying){
            audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.J)){
            transform.Rotate(Vector3.forward * Time.deltaTime * roatationMultiplier);
        }

        if (Input.GetKey(KeyCode.L)){
            transform.Rotate(-Vector3.forward * Time.deltaTime * roatationMultiplier);
        }
    }

}
