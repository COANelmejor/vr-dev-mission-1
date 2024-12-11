using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallBounceSound : MonoBehaviour
{
    private AudioSource bounceAudioSource;
    private Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bounceAudioSource = GetComponent<AudioSource>();
        ballRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {

        // Get rigidbody.velocity.magnitude to use as volume
        float volume = ballRigidbody.velocity.magnitude / 100;
        Debug.Log("Volume: " + volume);
        // Play the AudioClip when the GameObject collides with another GameObject
        bounceAudioSource.PlayOneShot(bounceAudioSource.clip, volume);
      
    }

}
