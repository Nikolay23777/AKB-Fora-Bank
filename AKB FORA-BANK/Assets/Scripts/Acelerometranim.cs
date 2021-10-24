using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometranim : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transf;
    private float xn;
    private float yn;
    private float zn;
    public float sila;
    void Start()
    {
       
    }
    public void function()
    {
 transf=gameObject.GetComponent<Transform>();
        xn = transf.rotation.x;
        yn = transf.rotation.y;
        zn = transf.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        //transf.rotation = Quaternion.Euler(xn+(Input.acceleration.x* sila), yn+ (Input.acceleration.y* sila), zn+ (Input.acceleration.z*sila));
    }
}
