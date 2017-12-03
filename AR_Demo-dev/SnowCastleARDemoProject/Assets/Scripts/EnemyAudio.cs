using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//play enemy audio randomly
public class EnemyAudio : MonoBehaviour {
    
    public AudioClip[] soundIdle;
    AudioSource audioSource;
    public float idleDelayTime;
    float soundTime, soundTimeDuration;
	
    // Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        soundTime = Time.time;
        soundTimeDuration = Random.Range(0, idleDelayTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > soundTime + soundTimeDuration)
        {
            PlayIdleSound();            
            idleDelayTime = Random.Range(0,idleDelayTime);
            soundTime = Time.time;
        }
	}

    void PlayIdleSound()
    {
        if(audioSource&&soundIdle.Length>0)
            audioSource.PlayOneShot(soundIdle[Random.Range(0,soundIdle.Length)]);
    }

}
