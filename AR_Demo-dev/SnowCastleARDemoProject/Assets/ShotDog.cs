using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDog : MonoBehaviour {
    GameObject parent; 
    Vector3 camLastPos;
    public GameObject iceBullet;
    public GameObject gunMuzzle;
    //GameObject muzzle;
    Vector3 screenCenterPoint;
    //Ray ray;
    //RaycastHit hit;
    //public LayerMask layer;
    //public LineRenderer laser;
    public AudioClip shotAudio;
    public AudioClip deadAudio;

    public GameObject bone;
    public Transform bonePos;
    void Fire()
    {
        GameObject boneClone = Instantiate(bone, bonePos.position, bonePos.rotation,transform);
        boneClone.GetComponent<Rigidbody>().velocity = transform.forward * 200;
        GetComponent<AudioSource>().PlayOneShot(shotAudio);
        Destroy(boneClone,3);
    }
    public void playDeadAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(deadAudio);
    }
    // Use this for initialization
    void Start()
    {
        screenCenterPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        timeFire = Time.time;
        timeFire2 = Time.time;
        parent = GameObject.FindGameObjectWithTag("Parent");
       // laser = GetComponentInChildren<LineRenderer>();
        camLastPos = Camera.main.transform.parent.transform.position;
    }

    float timeFire;
    float distance = 1f;

    public float timeFireDuration2 = 10f;
    private float timeFire2;

    // Update is called once per frame
    void Update()
    {

          
            Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 1000, Color.red);

        //ray cast a ray:
        //raycast a ray from center point of screen
        /*
            ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out hit, 2000, layer))
            {
            
            SetLaserPosition();
            */
            if (Input.GetMouseButtonDown(0) && Time.time > timeFire + timeFireDuration2)
                {
                    Fire();
                }
            
            /*else
            {
                laser.enabled = false;
            }*/
    }
    /*
    public GameObject laserTemp;
    private void SetLaserPosition()
    {
        timeFire2 = Time.time;
        //camera位置总变化，故 用相对坐标。               
        laser.enabled = true;
        laser.SetPosition(0, new Vector3(0,0,0));
        laserTemp.transform.position = hit.point;
        laser.SetPosition(1, laserTemp.transform.localPosition);
        
    }
    */

    /*
        void Fire1()
        {
            //Gun muzzle
            //muzzle = GameObject.Instantiate(gunMuzzle, Camera.main.ScreenToWorldPoint(screenCenterPoint), new Quaternion(0, 0, 0, 0), transform);
            //muzzle = GameObject.Instantiate(gunMuzzle, Camera.main.transform.position, new Quaternion(0, 0, 0, 0), transform);
            //Destroy(muzzle, 1);

                timeFire = Time.time;
                switch (hit.transform.tag)
                {
                    case "Enemy":
                        hit.transform.GetComponent<DogHealth>().GetDamage(51);
                        GetComponent<AudioSource>().PlayOneShot(deadAudio);

                    break;
                    default:
                        Instantiate(iceBullet, hit.point, iceBullet.transform.rotation, parent.transform);
                        GetComponent<AudioSource>().PlayOneShot(shotAudio);
                    break;
                }

        }
        */






}
