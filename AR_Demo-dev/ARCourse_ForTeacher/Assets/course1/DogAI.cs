using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject target;
	// Update is called once per frame
	void Update () {
        //GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);

    }
}
