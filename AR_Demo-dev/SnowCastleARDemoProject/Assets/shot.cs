using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        screenCenterPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        timeFire = Time.time;
    }

    float timeFire;
    public float timeFireDuration=0.5f;
	// Update is called once per frame
	void Update () {
    
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position+Camera.main.transform.forward*1000, Color.red);
        //if (Input.touchCount>0&&Time.time>timeFire+timeFireDuration)
        if (Input.GetMouseButtonDown(0)&& Time.time > timeFire + timeFireDuration)
        {           
            timeFire = Time.time;
            GetComponent<AudioSource>().PlayOneShot(shotAudio);
            Fire();
        }
	}

    public GameObject gunMuzzle;
    GameObject muzzle;
    Vector3 screenCenterPoint;
    Ray ray;
    RaycastHit hit;

    public AudioClip enemyHurt;
    public AudioClip shotAudio;
    public LayerMask layer;

    void Fire()
    {
        //Gun muzzle
        //muzzle = GameObject.Instantiate(gunMuzzle, Camera.main.ScreenToWorldPoint(screenCenterPoint), new Quaternion(0, 0, 0, 0), transform);
        muzzle = GameObject.Instantiate(gunMuzzle, Camera.main.transform.position, new Quaternion(0, 0, 0, 0), transform);
        Destroy(muzzle, 1);
      
        //raycast a ray from center point of screen
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out hit, 2000,layer))
        {
            Debug.Log("isRay***********************");
            switch (hit.transform.tag)
            {
                case "Enemy":
                    Debug.Log("***********************"+ hit.transform.name);
                    hit.transform.GetComponent<EnemyHealth>().currentHealth -=40;
                    hit.transform.GetComponent<AudioSource>().PlayOneShot(enemyHurt);
                    break;
                default:
                    break;
            }
        }
    }

}
