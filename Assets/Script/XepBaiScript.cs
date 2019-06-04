using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XepBaiScript : MonoBehaviour
{
    List<Sprite> Cards;
    GameObject controller;
    Vector2 oldPos;
    List<Dictionary<string, string>> Lstdic;
    // Use this for initialization
    void Start()
    {
        
        Cards = new List<Sprite>();
        Lstdic = new List<Dictionary<string, string>>();
        controller = GameObject.Find("Game_Controller");
        oldPos = new Vector2(-8, -4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void XepBai()
    {
        controller.GetComponent<Controller>().reset();

        List<Dictionary<string, string>> LstdicC = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> LstdicD = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> LstdicB = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> LstdicN = new List<Dictionary<string, string>>();


        AddLst(Controller.CardsPlayer);
        Debug.Log("CardList chua sap xep" + Lstdic);

        Controller.Cards.Clear();

        foreach (var a in Lstdic)
        {
            
            switch (a["chat"])
            {
                
                case "C": LstdicC.Add(a);  break;
                case "D": LstdicD.Add(a);  break;
                case "B": LstdicB.Add(a);  break;
                case "N": LstdicN.Add(a);  break;
            }
            

        }
       
        foreach(var a in Controller.Cards)
        {
            Debug.Log(a.name);
        }
        //SapXepNhoLon(Lstdic);
        //foreach(var a in Lstdic)
        //{
        //    Debug.Log(a["giatri"]);
        //}


        SapXepNhoLon(LstdicB);        
        SapXepNhoLon(LstdicN);        
        SapXepNhoLon(LstdicD);        
        SapXepNhoLon(LstdicC);       
        Lstdic.Clear();

        foreach(var a in LstdicB)
        {
            string ghepChuoi = GhepChuoi(a);
            Debug.Log("Bich/" + ghepChuoi);
            Controller.Cards.Add(Resources.Load<Sprite>("Bich/" + ghepChuoi));
        }
        foreach (var a in LstdicN)
        {
            string ghepChuoi = GhepChuoi(a);
            Debug.Log("Nhep/" + ghepChuoi);
            Controller.Cards.Add(Resources.Load<Sprite>("Nhep/" + ghepChuoi));
        }
        foreach (var a in LstdicD)
        {
            string ghepChuoi = GhepChuoi(a);
            Debug.Log("Do/" + ghepChuoi);
            Controller.Cards.Add(Resources.Load<Sprite>("Do/" + ghepChuoi));
        }
        foreach (var a in LstdicC)
        {
            
            string ghepChuoi = GhepChuoi(a);
            Debug.Log("Co/" + ghepChuoi);
            Controller.Cards.Add(Resources.Load<Sprite>("Co/" + ghepChuoi));
        }

        FillToList(LstdicB);
        FillToList(LstdicN);
        FillToList(LstdicD);
        FillToList(LstdicC);
        
        
        
        controller.GetComponent<Controller>().SapXepThuTuQuanBai();

       
    }

    

    void FillToList(List<Dictionary<string, string>> lst)
    {        
        foreach (var a in lst)
        {
            Lstdic.Add(a);
        }
    }
    void AddLst(List<GameObject> lstStr)
    {
        foreach (var a in lstStr)
        {
            string giatri = controller.GetComponent<Controller>().Giatri(a);
            string chat = controller.GetComponent<Controller>().Chat(a);
            Dictionary<string, string> dicCards = new Dictionary<string, string>();
            dicCards.Add("giatri", giatri);
            dicCards.Add("chat", chat);

            Lstdic.Add(dicCards);
        }
    }

    string GhepChuoi(Dictionary<string, string> dicStr)
    {
        string nameObj = "";
        string chat = dicStr["chat"];
        string giatri = dicStr["giatri"];
        nameObj = giatri + chat;
        return nameObj.Trim();
    }

    public void SapXepNhoLon(List<Dictionary<string, string>> lstDic)
    {
        foreach (var a in lstDic)
        {
            for (int i = 0; i < lstDic.Count -1; i++)
            {
                if (int.Parse(lstDic[i]["giatri"]) > int.Parse(lstDic[i + 1]["giatri"]))
                {
                    Dictionary<string, string> oldLisDic = new Dictionary<string, string>();
                    oldLisDic = lstDic[i];
                    lstDic[i] = lstDic[i + 1];
                    lstDic[i + 1] = oldLisDic;
                }
            }

        }
    }
}
