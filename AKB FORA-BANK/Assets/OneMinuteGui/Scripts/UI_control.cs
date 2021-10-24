using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_control : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img_btn;
    public Sprite[] img_btn_all;
  //  private MenuManager mm;
    public GameObject Bild_panel;
    public GameObject[] Bild_panels;

 
    public Text mani;
    private int manii;
    public int Mani{
        get
        {
            return manii;
        }
        set
        {
            manii = value;
        }
        }


    private int naselenie;
    public Text t_person;
    public int Naselenieadd
    {
        get
        {
            return naselenie;
        }

        set
        {
            t_person.text = "" + naselenie;
            naselenie = value;

        }
    }
    public void ADD_person()
    {
        Naselenieadd++;
    }
    private int coinb;
    public void BTNBild()
    {
        coinb++;
        if (coinb % 2 == 1)
        {
            img_btn.sprite = img_btn_all[1];
            Bild_panel.SetActive(true);
        }
        else
        {
            img_btn.sprite = img_btn_all[0];
            Bild_panel.SetActive(false);
            foreach( GameObject g in Bild_panels)
            {
                g.SetActive(false);
            }
        }
    }
    public void ADD_person_coin(int person)
    {
        Naselenieadd+=person;
    }

    void Start()
    {
     //   mm=GetComponent<MenuManager>();
    }
    /*
    public void GOREJIM(int id)
    {
        img_btn.sprite = img_btn_all[id];
        mm.GoBack();
        mm.coin++;
        if (id == 0)
        {
            Person_panel.SetActive(true);
            Road_panel.SetActive(false);
            Resurs_panel.SetActive(false);
        }
        else if (id == 1)
        {
           Person_panel.SetActive(false);
            Road_panel.SetActive(true);
            Resurs_panel.SetActive(false);
        }
        else if (id == 2)
        {
            Person_panel.SetActive(false);
            Road_panel.SetActive(false);
            Resurs_panel.SetActive(false);
        }
        else if (id == 3)
        {
            Person_panel.SetActive(false);
            Road_panel.SetActive(false);
            Resurs_panel.SetActive(true);
        }

    }
    */
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public GameObject game;
    public GameObject start_menu;
  //  public DayNight DN;

    public void PLAY()
    {
        start_menu.SetActive(false);
        game.SetActive(true);

    }
    public void RESTART()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       //Application.LoadLevel(Application.loadedLevel);
    }
    /*
    public void _0X()
    {
        DN.fullDay = int.MaxValue;
    }
    public void _1X()
    {
        DN.fullDay = 240;
    }
    public void _2X()
    {
        DN.fullDay = 120;
    }
    public void _3X()
    {
        DN.fullDay = 60;
    }
    public void _4X()
    {
        DN.fullDay = 30;
    }
    */
    // Update is called once per frame

}
