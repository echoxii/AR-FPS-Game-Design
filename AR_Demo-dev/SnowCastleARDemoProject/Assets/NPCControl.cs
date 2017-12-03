using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCControl : MonoBehaviour {
    Animator animator;
    NavMeshAgent agent;

    Transform bloodBar;
    public Texture2D bloodBarRed;//血条贴图

    public float currentHealth=100;
    float startHealth;
    GameObject player;
    int attackCount;
    // Use this for initialization
    void Start () {
        player= GameObject.FindGameObjectWithTag("Player");        
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.transform.position);

        bloodBar = transform.Find("BloodBar");
        Debug.Log("*************"+bloodBar.name);        
        bloodBarRed = new Texture2D(512, 32);//新建一个贴图，用以变化后付给cube
        bloodBarRed.wrapMode = TextureWrapMode.Clamp;//拉伸改图

        startHealth = currentHealth;

	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeState();      //idle\run\attack
        UpdateBloodBar();   //血条
        TakeDamage();
       
    }

    private void TakeDamage()
    {
        
    }

    public void ChangeState()
    {
        //run
        if (agent.remainingDistance > 1 || agent.remainingDistance == 1)
            animator.SetInteger("AnimatorState", 1);//1----run
        //Attack
        if (agent.remainingDistance < 1)
        { 
            animator.SetInteger("AnimatorState", 2);//2----eat
            Attack();
        }
    }
    public  void Attack()
    {
        player.GetComponent<PlayerHealth>().currentHealth -= attackCount;
    }

    public void UpdateBloodBar()
    {
        bloodBar.LookAt(Camera.main.transform.position); //朝向摄像机

        float currentRed = currentHealth * bloodBarRed.width / startHealth;
        for (var x = 0; x < bloodBarRed.width; x++)
        {
            // 对每个坐标点
            for (var y = 0; y < bloodBarRed.height; y++)
            {//循环执行y轴从0开始，y轴小于血条的宽的话执行下面，否则+
                if (x < currentRed)
                    bloodBarRed.SetPixel(x, y, Color.red);   //x小于血条长度的范围涂成红色，
                else
                    bloodBarRed.SetPixel(x, y, Color.black);         //其他部位涂成黑色
            }
            bloodBarRed.Apply(); // 应用该图
            bloodBar.gameObject.GetComponent<Renderer>().material.mainTexture = bloodBarRed; // 将修改后的贴图给血条Cube
        }
    }
}
