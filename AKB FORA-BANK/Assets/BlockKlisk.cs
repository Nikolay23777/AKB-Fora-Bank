using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockKlisk : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    
    void Start()
    {
        
    }

    public void AddOpenBtn()
    {
        animator.SetBool("IsOpen",true);
    }
    public void CloseBtn()
    {
        animator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
