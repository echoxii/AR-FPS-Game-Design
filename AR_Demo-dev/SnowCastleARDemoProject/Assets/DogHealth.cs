using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DogHealth : MonoBehaviour {
    public int health=100;
    public int currentHealth;
    public GameObject particle;
    public GameObject EnemyDog;
    public GameObject particleEffect2;
    bool isDead = false;
    bool isGameOver = false;
    NavMeshAgent agent;
    Animator ani;

	// Use this for initialization
	void Start () {
        currentHealth = health;
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        Debug.Log("******isDead:" + isDead + "    :" + PlayerPrefs.GetInt("GoneDogs"));
        if (currentHealth < 0 &&!isDead)
            Dead();
        /*
        if (!(agent.remainingDistance > agent.stoppingDistance))
        {
            ani.SetTrigger("attack");
        }
        */

	}
    void Dead()
    {       
        agent.Stop();
        Instantiate(particleEffect2, transform.position, Quaternion.identity);
        isDead = true;
        GetComponent<Collider>().enabled = false;
        ani.SetTrigger("idle");
        Destroy(this.gameObject,1);
        Debug.Log("if Dead():"+ PlayerPrefs.GetInt("GoneDogs"));
        int temp = PlayerPrefs.GetInt("GoneDogs");
        //PlayerPrefs.SetInt("GoneDogs", temp + 1);
    }


    public void GetDamage(int damage)
    {
        currentHealth -=damage;
    }

}
