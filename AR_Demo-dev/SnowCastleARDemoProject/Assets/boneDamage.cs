using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<DogHealth>().GetDamage(101);
            transform.parent.GetComponent<ShotDog>().playDeadAudio();     
        }
    }
}
