using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class Parser : MonoBehaviour
{
    

    private Save777 sv = new Save777();
    private string path;
  //  public Save777 listdate;

    private void Start()
    {
  
    }
    public Text tttt;
    public List<Save> LoadMap()
    {
        print("****");
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Vipiska.json");
#else
        path = Path.Combine(Application.dataPath, "Vipiska.json");
#endif
        List<Save> savemek = new List<Save>();
        if (File.Exists(path))
        {
           // tttt.text = "!!! " + path;
            sv = JsonUtility.FromJson<Save777>(File.ReadAllText(path));
            foreach (Save sv in sv.data)
            {
                print("7777");
                savemek.Add(sv);
            }
          //  tttt.text = "**** "+sv.data.Length;

            return savemek;
          
        }
        return null;

    }


#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}
[Serializable]
public class SaveDataSerialization
{
    public List<Save> spisok = new List<Save>();

    public void AddData(string type, ulong date, ulong tranDate, string operationType, float amount, string comment, string accountNumber, int currencyCodeNumeric, string merchantName,Save2 fastPaymentData,int MCC)
    {
       spisok.Add(new Save(type , date, tranDate,operationType, amount, comment,accountNumber,currencyCodeNumeric,merchantName,fastPaymentData, MCC));
    }
    public void DestroyStructureData()
    {
       
    }
}
[Serializable]
public class Save777
{
    public int statusCode;
    public string errorMessage;
    public Save[] data;

}

[Serializable]

public class Save
{
    public string type;//
    public ulong date;//дата операции
    public ulong tranDate;//дата регистрации транзакции у банка
    public string operationType;
    public float amount;// перевод денег
    public string comment;//коментарий
    public string accountNumber;
    public int currencyCodeNumeric;
    public string merchantName;
    public Save2 fastPaymentData;
    public int MCC;
    public Save(string type, ulong date, ulong tranDate, string operationType, float amount, string comment, string accountNumber, int currencyCodeNumeric, string merchantName, Save2 fastPaymentData,int MCC)
    {
        this.type = type;
        this.date = date;
        this.tranDate = tranDate;
        this.operationType = operationType;
        this.amount = amount;
        this.comment = comment;
        this.accountNumber = accountNumber;
        this.currencyCodeNumeric = currencyCodeNumeric;
        this.merchantName = merchantName;
        this.fastPaymentData = fastPaymentData;
        this.MCC = MCC;



    }

}

[Serializable]
public class Save2
{
    public string foreignName;//
    public string foreignPhoneNumber;
    public string foreignBankBIC;
    public string operationType;
    public string foreignBankID;
    public string foreignBankName;
    public string documentComment;


}