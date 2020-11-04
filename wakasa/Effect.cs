using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {


    public Transform target;
    public float speed = 0.1f;
    private Vector3 vec;


    void Start()
    {
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
        transform.position += transform.forward * speed;
    }
}
