using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public Rigidbody rb;

	void Start()
    {
        Transform transform = rb.transform;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
	}
}
