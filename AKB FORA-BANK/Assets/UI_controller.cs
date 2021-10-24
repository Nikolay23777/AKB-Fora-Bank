using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public void AddFilter()
    {
        animator.SetBool("Isfiler", true);
    }
    public void CloseFilter()
    {
        animator.SetBool("Isfiler", false);
    }
    void Start()
    {
        
    }
    public GameObject a;
    public GameObject b;
    private bool isff;
    public void StartGrapth()
    {
        a.SetActive(true);
        b.SetActive(true);
        isff = true;
    }
    public void CloseGrapth()
    {
        a.SetActive(false);
        b.SetActive(false);
        isff = false;
    }
    /*
    private Transform transf;
    private float xn;
    private float yn;
    private float zn;
    public float sila;
    public void function()
    {
        transf = b.GetComponent<Transform>();
        xn = transf.rotation.x;
        yn = transf.rotation.y;
        zn = transf.rotation.z;
    }
    */
    // Update is called once per frame
    void Update()
    {
     //   if(isff)
      //  transf.rotation = Quaternion.Euler(xn + (Input.acceleration.x * sila), yn + (Input.acceleration.y * sila), zn + (Input.acceleration.z * sila));
    }
}
