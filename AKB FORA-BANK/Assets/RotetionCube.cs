using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotetionCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] GameObject go;

    Coroutine coroutine;

  //  public Transform target;
    public float speed = 5f;
    // Update is called once per frame

    IEnumerator c_Rotate(float angle, float intensity)
    {
        var me = go.transform;
        var to = me.rotation * Quaternion.Euler(0.0f,angle ,0.0f );

        while (true)
        {
            me.rotation = Quaternion.Lerp(me.rotation, to, intensity * Time.deltaTime);

            if (Quaternion.Angle(me.rotation, to) < 0.1f)
            {
                coroutine = null;
                me.rotation = to;
                yield break;
            }

            yield return null;
        }
    }
    public Text ttt;

    void Update()
    {
       // ttt.text = " " + Input.acceleration;
        if (Input.acceleration.x >= 0.5)
        {
           if (coroutine == null)
            {
                coroutine = StartCoroutine(c_Rotate(90.0f, 2.5f));
            }
        }
        if (Input.acceleration.x <= -0.5)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(c_Rotate(-90.0f, 2.5f));
            }
        }
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        /*
     // transform.LookAt(target);
        Vector3 direction = target.transform.position - transform.position;
      Quaternion rotation = Quaternion.LookRotation(direction);
      transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed* Time.deltaTime);
        */

    }
}
