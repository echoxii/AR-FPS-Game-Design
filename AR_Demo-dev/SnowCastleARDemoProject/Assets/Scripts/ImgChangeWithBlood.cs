using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgChangeWithBlood : MonoBehaviour {
    GameObject player;
    RectTransform bloodRect;
    float widthInit;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        bloodRect = GetComponentInChildren<RectTransform>();
        widthInit = bloodRect.rect.width;

    }
	
	// Update is called once per frame
	void Update () {
        //bloodRect = new RectTransform();
	}
}
