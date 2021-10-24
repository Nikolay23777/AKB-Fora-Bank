using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DateCreator : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Save> listdate;
    public List<Save> Mylistdate;
    public Parser parser;
    public string accountNumber;
    public GameObject GMblock;
    public Transform[] box;
    public RectTransform[] conteyner;
    public int indexstorona;

    public GameObject DateBlock;

    public List<GameObject> listkategory1;
    public List<Save> sortcredit;
    public List<Save> sortdebit;

    public List<int> bbc;
    void Start()
    {
        GameObject clone;
        listdate = parser.LoadMap();


     
        foreach (Save sv in listdate)
        {
            if (sv.accountNumber == accountNumber)
            {
                Mylistdate.Add(sv);
            }
            
           
                bbc.Add(sv.MCC);
            
                
           


        }

        Creatorrr(Mylistdate);



        foreach (Save sv in Mylistdate)
        {
            if (sv.operationType == "CREDIT")
            {
                sortcredit.Add(sv);
            }
            else
            {
                sortdebit.Add(sv);
            }
        }
        indexstorona = 1;
        Creatorrr(sortcredit);
        indexstorona = 2;
        Creatorrr(sortdebit);
        indexstorona = 3;
        Creatorrr(sortcredit);



        /*
        foreach (Save sv in Mylistdate)
        {
            // clone=Instantiate(GMblock,)
            clone = Instantiate(GMblock, new Vector3(0, 0, 0), Quaternion.identity);
            // clone.GetComponent<RectTransform>().shi = 100;
            //  clone.GetComponent<RectTransform>().anchoredPosition = new Vector2(563, -136f);

            clone.transform.SetParent(box);
            //    clone.GetComponent<RectTransform>().anchoredPosition = new Vector3(563, -136f,0);
            //  clone.anchoredPosition = new Vector3(_fieldsBound.x, _fieldsBound.y, 0);

            //  clone.transform.
            // print(clone.GetComponent<RectTransform>().anchoredPosition.);
            clone.GetComponent<SetDateToBlosk>().ToBlock(sv);

            clone.GetComponent<RectTransform>().transform.localScale = new Vector3(1.67f, 1.88f, 1.67f);
          //  clone.GetComponent<GMblock>().But.onClick.AddListener(delegate { methodDell(clone, item); });
        }
        */
        //conteyner.transform.localScale = new Vector3(1f, 1f, 0.0001f);


        print(Mylistdate.Count);
        // print(listdate.Count);

    }
  
    public DateTime GetDate(ulong date)
    {
        var dt = DateTimeOffset.FromUnixTimeMilliseconds(1634418000000);
        return (DateTime)dt.DateTime;
    }
    public void Creatorrr(List<Save> List)
    {
        GameObject clone;
        DateTime dtcurrent = new DateTime();
        bool isdatespawn = false;
        foreach (Save sv in List)
        {
           // print(List.Count);
            // clone=Instantiate(GMblock,)

            if (dtcurrent == GetDate(sv.tranDate))
            {
                isdatespawn = true;
            }
            else
            {
                isdatespawn = false;
            }
            if (isdatespawn == false)
            {

                clone = Instantiate(DateBlock, new Vector3(0, 0, 0), Quaternion.identity);
                clone.GetComponent<SetDateBlock>().addText(GetDate(sv.tranDate).Date + " ");
                clone.transform.SetParent(box[indexstorona]);
                clone.GetComponent<RectTransform>().transform.localScale = new Vector3(1.67f, 1.88f, 1.67f);
                listkategory1.Add(clone);

            }
            //if (isdatespawn) {
            clone = Instantiate(GMblock, new Vector3(0, 0, 0), Quaternion.identity);


            clone.GetComponent<SetDateToBlosk>().ToBlock(sv);
            clone.transform.SetParent(box[indexstorona]);
            clone.GetComponent<RectTransform>().transform.localScale = new Vector3(1.67f, 1.88f, 1.67f);
            listkategory1.Add(clone);

            dtcurrent = GetDate(sv.tranDate);
            //  clone.GetComponent<GMblock>().But.onClick.AddListener(delegate { methodDell(clone, item); });
        }
 
        conteyner[indexstorona].transform.localScale = new Vector3(1f, 1f, 0.0002f);
    }
    public void SortDateNedela()
    {
        foreach(GameObject gm in listkategory1)
        {
            Destroy(gm);
        }
        listkategory1.Clear();

        Creatorrr(Sort(Mylistdate,1, DateTime.Today.AddDays(-2), DateTime.Now,false));
        conteyner[indexstorona].transform.localScale = new Vector3(1f, 1f, 0.00001f);
    }
    public void SortDateNau()
    {

        foreach (GameObject gm in listkategory1)
        {
            Destroy(gm);
        }
        listkategory1.Clear();
        //Creatorrr(Sort(Mylistdate, 1, DateTime.Now, DateTime.Now, false));
        /*
        List<Save> ggg;
        foreach(Save l in Mylistdate)
        {
            if (l.FromULong(l.tranDate))
            {

            }
        }
        */
        conteyner[indexstorona].transform.localScale = new Vector3(1f, 1f, 0.00001f);
    }

    public DateTime FromULong(ulong ULongDate)
    {
        DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(ULongDate)).DateTime;
        return dt;
    }

    List<Save> Sort(List<Save> List, int SortType, DateTime? start = null, DateTime? end = null, bool Reverse = false)
    {
        List<Save> ReturnedList = new List<Save>();
        if (List != null)
        {
            switch (SortType)
            {
                case 1:
                    ReturnedList = List;
                    if (start != null && end != null)
                    {
                        //За период
                        foreach (Save l in List)
                        {
                            if (FromULong(l.date) < end & FromULong(l.date) > start)
                                ReturnedList.Add(l);
                            print("///");
                        }
                        if (!Reverse)
                            ReturnedList.Sort((x, y) => x.date.CompareTo(y.date));
                        else ReturnedList.Sort((x, y) => -x.date.CompareTo(y.date));
                    }
                    break;
                case 2:
                    //По датам
                    ReturnedList = List;
                    if (!Reverse)
                        ReturnedList.Sort((x, y) => x.date.CompareTo(y.date));
                    else ReturnedList.Sort((x, y) => -x.date.CompareTo(y.date));
                    break;
                case 3:
                    //По количеству
                    ReturnedList = List;
                    if (!Reverse)
                        ReturnedList.Sort((x, y) => x.amount.CompareTo(y.amount));
                    else ReturnedList.Sort((x, y) => -x.amount.CompareTo(y.amount));
                    break;
                default:
                    ReturnedList = List;
                    break;
            }
        }
        return ReturnedList;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
