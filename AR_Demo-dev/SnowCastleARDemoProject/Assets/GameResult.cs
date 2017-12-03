using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("GoneDogs", 0);

    }

    public AudioClip failAudio;
    public AudioClip successAudio;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    bool isOver = false;
    public int DogAmount=1;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !isOver)
        {
            Fail();
        }
    }

    // Update is called once per frame
    void Update () {      
        if ( (!(DogAmount> PlayerPrefs.GetInt("GoneDogs")))&&!isOver)
        {
            Win();
        }
	}
    void Win()
    {
        gameWinUI.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(successAudio);
        isOver = true;
        Time.timeScale = 0;
    }
    void Fail()
    {
        gameOverUI.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(failAudio);
        isOver = true;
    }




}
