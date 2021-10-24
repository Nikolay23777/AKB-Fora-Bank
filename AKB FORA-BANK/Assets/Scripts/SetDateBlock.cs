using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDateBlock : MonoBehaviour
{
    public Text datatext;
    // Start is called before the first frame update
    public void addText(string date_text)
    {
        datatext.text = " " + date_text;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
