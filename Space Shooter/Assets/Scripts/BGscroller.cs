using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour {
	public float scrollSpeed;
	private Vector3 startPosition;
	public float titleSizeZ;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPostion=	Mathf.Repeat (Time.time * scrollSpeed,titleSizeZ);
		transform.position = startPosition + Vector3.forward * newPostion;
	}
}
