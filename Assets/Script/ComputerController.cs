using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    List<GameObject> lstHaBai;
    CardController objMinController;
    GameObject objMin;
    GameObject cardOnDesk;
    CardController _cardOnDeskController = null;
    static List<GameObject> lstCard;
    // Use this for initialization
    void Start()
    {
        lstHaBai = new List<GameObject>();
        lstCard = new List<GameObject>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Controller.WaitTime - Time.time <= 1)
        //{
        //    SoSanh();

        //}
        SoSanh();
    }
    void SoSanh()
    {
        if (Controller.Turn == 2)
        {
            TimBai();
        }

    }
    

    void TimBai()
    {
        Debug.Log("TimBai");
        Debug.Log("CCCCCCCCCCCC" + Controller.CardOnDesk.Count);

        if (Controller.CardOnDesk.Count == 1)
        {
            Debug.Log("CardOnDesk = 1");
            foreach (var a in Controller.CardOnDesk)
            {
                cardOnDesk = a;
                _cardOnDeskController = cardOnDesk.GetComponent<CardController>();
            }
            foreach (var a in Controller.CardsComputer)
            {
                CardController _cardController = a.GetComponent<CardController>();
                _cardController.AddGiaTri((a.name).Trim());

                if (_cardController.tenChat == _cardOnDeskController.tenChat && int.Parse(_cardController.giaTri) > int.Parse(_cardOnDeskController.giaTri))
                {
                    lstCard.Add(a);
                }
            }
            if (lstCard.Count != 0)
            {
                objMin = TimGiaTriNhoNhat(lstCard);
                objMinController = objMin.GetComponent<CardController>();
                objMin.GetComponent<SpriteRenderer>().sortingOrder = Controller.thutuhabai;
                Controller.thutuhabai++;
                switch (objMinController.tenChat)
                {
                    case "C": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Co/" + objMin.name); break;
                    case "D": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Do/" + objMin.name); break;
                    case "B": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bich/" + objMin.name); break;
                    case "N": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Nhep/" + objMin.name); break;
                }                
                Controller.CardComputerOnDesk.Add(objMin);
                lstHaBai.Add(objMin);
                Controller.CardsComputer.Remove(objMin);
            }

            else
            {
                GameObject.Find("Canvas").GetComponent<BoLuotScript>().BoLuot();
            }
            GameObject.Find("Canvas").GetComponent<HaBaiScript>().MoveCard(lstHaBai);
            lstCard.Clear();
            Controller.CardOnDesk.Clear();

            Controller.Turn = 1;
        }
        else if(Controller.CardOnDesk.Count == 0)
        {
            Debug.Log("CardOnDesk = 0");
            objMin = TimGiaTriNhoNhat(Controller.CardsComputer);
            objMinController = objMin.GetComponent<CardController>();
            objMin.GetComponent<SpriteRenderer>().sortingOrder = Controller.thutuhabai;
            Controller.thutuhabai++;
            switch (objMinController.tenChat)
            {
                case "C": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Co/" + objMin.name); break;
                case "D": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Do/" + objMin.name); break;
                case "B": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bich/" + objMin.name); break;
                case "N": objMin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Nhep/" + objMin.name); break;
            }
            Controller.CardComputerOnDesk.Add(objMin);
            lstHaBai.Add(objMin);
            GameObject.Find("Canvas").GetComponent<HaBaiScript>().MoveCard(lstHaBai);
            lstCard.Clear();
            Controller.CardOnDesk.Clear();
            Controller.CardsComputer.Remove(objMin);
            Controller.Turn = 1;
        }
        lstHaBai.Clear();
    }

    GameObject TimGiaTriNhoNhat(List<GameObject> lst)
    {
        GameObject lastObj = null;
        if (lst.Count == 1)
        {
            foreach(var a in lst)
            {
                lastObj = a;
            }
        }
        else
        {
            for (int j = lst.Count - 1; j > 0; j--)
            {
                for (int i = lst.Count - 1; i > 0; i--)
                {
                    int lstI = int.Parse(lst[i].GetComponent<CardController>().giaTri);
                    int lstII = int.Parse(lst[i - 1].GetComponent<CardController>().giaTri);
                    if (lstI > lstII)
                    {
                        GameObject oldObj;
                        oldObj = lst[i - 1];
                        lst[i - 1] = lst[i];
                        lst[i] = oldObj;
                    }
                }
                lastObj = lst[lst.Count - 1];
            }

        }
        return lastObj;
    }
}
