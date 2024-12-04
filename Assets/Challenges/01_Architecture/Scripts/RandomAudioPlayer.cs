using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] audioClips;
    private AudioSource audioSource;

    [SerializeField]
    private bool isPlaying = false;

    [SerializeField]
    private AudioClip currentAudioClip;
    [SerializeField]
    private float minTimeBetweenPlays = 1f;
    [SerializeField]
    private float maxTimeBetweenPlays = 5f;

    [SerializeField]
    private float rotationSpeedX = 6f;

    private GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
        // Get the parent GameObject
        parentGameObject = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the GameObject around the X axis
        parentGameObject.transform.Rotate(0, rotationSpeedX * Time.deltaTime, 0);

        // If the AudioSource is not playing
        if (!isPlaying) {
            isPlaying = true;
            // Play a random AudioClip from the audioClips array
            currentAudioClip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.clip = currentAudioClip;
            audioSource.Play();
            // Set the time to wait before playing the next AudioClip
            float timeToWait = Random.Range(minTimeBetweenPlays, maxTimeBetweenPlays);
            // Wait for the timeToWait before playing the next AudioClip
            StartCoroutine(WaitAndPlay(timeToWait));
        }

    }

    // Coroutine to wait for a given time and then play the next AudioClip
    IEnumerator WaitAndPlay(float timeToWait) {
        isPlaying = true;
        yield return new WaitForSeconds(timeToWait);
        isPlaying = false;
    }
}
