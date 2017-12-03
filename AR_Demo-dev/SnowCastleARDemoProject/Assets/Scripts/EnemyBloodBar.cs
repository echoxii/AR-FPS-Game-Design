using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBloodBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        bloodBar = transform.Find("BloodBar");
        enemyHealth = GetComponent<EnemyHealth>();
        bloodBarRed = new Texture2D(512, 32);//新建一个贴图，用以变化后付给cube
        bloodBarRed.wrapMode = TextureWrapMode.Clamp;//拉伸改图         
    }
	
	// Update is called once per frame
	void Update () {
        UpdateBloodBar();
    }
    Transform bloodBar;
    public Texture2D bloodBarRed;
    EnemyHealth enemyHealth;
    public void UpdateBloodBar()
    {
        //Debug.Log("bloodBar     : "+bloodBar.name+","+bloodBar.parent.name);
        bloodBar.LookAt(Camera.main.transform.position); //朝向摄像机
        float currentRed = enemyHealth.currentHealth * bloodBarRed.width / enemyHealth.startHealth;
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
