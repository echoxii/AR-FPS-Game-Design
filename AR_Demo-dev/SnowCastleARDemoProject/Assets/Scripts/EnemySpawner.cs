using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject parent;
    
    public GameObject[] objectman;
    public float timeSpawnDuration = 3;
    public int MaxObject = 10;
 
    public float timeSpawn = 0;
    private int indexSpawn;
    private List<GameObject> spawnList = new List<GameObject>();
    
	// Use this for initialization
	void Start () {
        timeSpawn = Time.time;
        parent = GameObject.FindGameObjectWithTag("Parent");
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnList.Count < MaxObject&&Time.time>timeSpawn+timeSpawnDuration)
        {
            indexSpawn = Random.Range(0, objectman.Length);
            int deltaX = Random.Range(-(int)(this.transform.localScale.x / 2.0f), (int)(this.transform.localScale.x / 2.0f));
            int deltaZ= Random.Range(-(int)(this.transform.localScale.z / 2.0f), (int)(this.transform.localScale.z / 2.0f));
            /*float deltaX = Random.RandomRange(-transform.localScale.x / 2.0f, transform.localScale.x / 2.0f);
            float deltaZ = Random.RandomRange(-transform.localScale.z / 2.0f, transform.local1Scale.z / 2.0f);*/
            
            Vector3 spawnPoint = transform.localPosition + new Vector3(deltaX, 0, deltaZ);

            GameObject obj=Instantiate(objectman[indexSpawn],transform.position,Quaternion.identity,parent.transform);
            obj.transform.localPosition = spawnPoint;
            
            if (obj)
                spawnList.Add(obj);
            
            timeSpawn = Time.time;            
        }
	}
}
