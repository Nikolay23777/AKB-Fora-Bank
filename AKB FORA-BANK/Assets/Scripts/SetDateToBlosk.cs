using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDateToBlosk : MonoBehaviour
{
    // Start is called before the first frame update
    public Text title;
    public Image maniimg;
    public Text TextMani;
    public Text TextDescription;
    public Sprite[] toikobalance;
    public Text allTextDescription;
    public Text DateOperation;

    public Text Tfio;
    public Text Tphonenumber;
    public Text Tbik;
    public Text TbankName;

    public Image image_ikons;
    public Sprite[] sprites;
    public DateTime GetDate(ulong date)
    {
        var dt = DateTimeOffset.FromUnixTimeMilliseconds(1634418000000);
        return (DateTime)dt.DateTime;
    }

    public void ToBlock(Save sv)
    {
        if(sv.operationType== "DEBIT")
        {
            maniimg.sprite = toikobalance[0];
            TextMani.text = "- " + sv.amount;
        }
        else
        {
            maniimg.sprite = toikobalance[1];
            TextMani.text = "+ " + sv.amount;
        }
        title.text = sv.merchantName;
        string str;
        if (sv.comment.Length > 20)
        {
             str = sv.comment.Substring(0, 20) + "...";
        }
        else
        {
            str = sv.comment;
        }
        TextDescription.text = str;
        allTextDescription.text = sv.comment;
        DateOperation.text = GetDate(sv.tranDate)+"";

        if (sv.fastPaymentData != null || sv.fastPaymentData.foreignName.Length<5)
        {
            Tfio.text = "" + sv.fastPaymentData.foreignName;
            Tphonenumber.text = "" + sv.fastPaymentData.foreignPhoneNumber.Replace(" ", ""); ;
            TbankName.text = "" + sv.fastPaymentData.foreignBankName;
            Tbik.text = "BIC " + sv.fastPaymentData.foreignBankBIC;
        }


        image_ikons.sprite= SetSprite(sv.MCC);
        //TextMani.text = "" + sv.amount; 

    }
    public Sprite SetSprite(int bbc)
    {
        if(bbc== 5814)
        {
            return sprites[1];
        }
        else if (bbc == 6011)
        {
            return sprites[2];
        }
        else if (bbc == 5999)
        {
            return sprites[3];
        }
        else if (bbc == 6012)
        {
            return sprites[4];
        }
        else if (bbc == 7372)
        {
            return sprites[5];
        }
        else 
        {
            return sprites[0];
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
