using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {    
    Dictionary<string, string> dicCards;

    GameObject controller;

    bool clickCard;
    Vector2 oldPosCard;

    public string tenChat;
    public string giaTri;
    public string Kieuchat;
    // Use this for initialization
    void Start () {
        dicCards = new Dictionary<string, string>();
        clickCard = false;
        controller = GameObject.Find("Game_Controller");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        Debug.Log("Click");

        if (!clickCard)
        {
            oldPosCard = this.transform.position;
            this.transform.position += new Vector3(0, 0.1f);
            clickCard = true;
            Controller.CardChoose.Add(this.gameObject);
            tenChat = controller.GetComponent<Controller>().Chat(this.gameObject);
            giaTri = controller.GetComponent<Controller>().Giatri(this.gameObject);
            Kieuchat = kieuchat(tenChat);
            dicCards.Add("chat", tenChat);
            dicCards.Add("giatri", giaTri);

            Controller.ListDic.Add(dicCards);
            //foreach(var a in Controller.ListDic)
            //{
            //    foreach(var b in a)
            //    {
            //        Debug.Log("Key :" + b.Key + " Values :" + b.Value);
            //    }
                
            //}
            
        }
        else if (clickCard)
        {
            this.transform.position = oldPosCard;
            clickCard = false;
            Controller.CardChoose.Remove(this.gameObject);
            
            dicCards.Remove("chat");
            dicCards.Remove("giatri");

            Controller.ListDic.Remove(dicCards);
            //foreach (var a in Controller.ListDic)
            //{
            //    Debug.Log("Key :" + a.Keys + " Values :" + a.Values);
            //}
        }
    }

    string kieuchat(string chat)
    {
        string strkieuchat = "";
        if(chat == "C" || chat == "D")
        {
            strkieuchat = "Red";
        }
        else if(chat == "N" || chat == "B")
        {
            strkieuchat = "Black";
        }
        return strkieuchat;
    }

    
}
