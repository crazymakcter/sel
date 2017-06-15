using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverVfx : MonoBehaviour {

	public float Speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.up * Speed;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Asteroid")
		{
			Destroy(gameObject);
		}
		
	}
}
