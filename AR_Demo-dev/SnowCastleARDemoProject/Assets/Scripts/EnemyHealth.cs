using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float currentHealth=100;
    public float startHealth;
	// Use this for initialization
	void Start () {
        startHealth = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth < 0)
        {
            Destroy(transform.gameObject);
            //enemy死亡
            Debug.Log("die...............");
        }
	}
}
