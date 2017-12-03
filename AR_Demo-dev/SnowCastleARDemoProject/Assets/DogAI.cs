using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DogAI : MonoBehaviour {
    GameObject player;
    NavMeshAgent agent;
    DogState state;
    DogState stateNow;
    Animator anim;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        state = DogState.Idle;
        anim=GetComponent<Animator>();
        stateNow = state;
    }
	enum DogState
    {
        Attack,Idle,Walk
    }
	// Update is called once per frame
	void Update () {
        
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            state = DogState.Walk;
        }
        else
        {
            state = DogState.Attack;
        }
        //如果状态改变
        if (stateNow != state)
        {
            stateNow = state;
            ChangeState();
        }
	}

    void ChangeState() {
        switch (state)
        {
            case DogState.Idle:
                anim.SetTrigger("idle");
                break;
            case DogState.Attack:
                anim.SetTrigger("attack");
                break;
            case DogState.Walk:
                anim.SetTrigger("walk");
                break;
            default:
                break;
        }
    }

}
