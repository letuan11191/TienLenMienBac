using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static List<GameObject> CardChoose;
    public static Dictionary<string, string> DicCardChoose;
    public static List<Dictionary<string, string>> ListDic;

    public GameObject PlayerCards;
    public GameObject ComputerCards;

    static List<Sprite> AllCards;
    public static List<Sprite> Cards;
    static List<string> ComCard;

    public static List<GameObject> CardsPlayer;
    public static List<Sprite> CardsPlayerList;

    public static List<GameObject> CardsComputer;

    public static string[,] arrayCardsString;

    Sprite[] arrayCards;
    float posObj;


    public static bool TurnPlayer;
    public static bool TurnCom;

    public static GameObject AObj;

    Vector2 oldPos;
    Vector2 oldPosCom;
    // Use this for initialization
    void Start()
    {
        AObj = GameObject.Find("A");

        ListDic = new List<Dictionary<string, string>>();
        CardChoose = new List<GameObject>();

        oldPos = new Vector2(-8, -4);
        oldPosCom = new Vector2(-8, 4);
        AllCards = new List<Sprite>();
        Cards = new List<Sprite>();
        arrayCards = Resources.LoadAll<Sprite>("");
        foreach (Sprite a in arrayCards)
        {
            AllCards.Add(a);
        }

        CardsPlayer = new List<GameObject>();
        CardsComputer = new List<GameObject>();
        AddPlayerCards();
        SapXepThuTuQuanBai();
        SapXepBaiComputer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddPlayerCards()
    {

        for (int i = 0; i < 13; i++)
        {
            int rd = Random.Range(0, AllCards.Count - 1);
            Cards.Add(AllCards[rd]);
            AllCards.Remove(AllCards[rd]);
        }


    }

    public void SapXepThuTuQuanBai()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            GameObject objCards = Instantiate(PlayerCards);
            //objCards.transform.parent = GameObject.Find("PlayerCards").transform;
            objCards.AddComponent<SpriteRenderer>();

            objCards.GetComponent<SpriteRenderer>().sprite = Cards[i];
            objCards.transform.parent = AObj.transform;

            objCards.AddComponent<CardController>();
            objCards.AddComponent<BoxCollider2D>();
            objCards.transform.position = oldPos;
            oldPos += new Vector2(this.transform.position.x + objCards.GetComponent<SpriteRenderer>().bounds.size.x, 0);

            CardsPlayer.Add(objCards);
            //CardsPlayerList.Add(objCards.GetComponent<SpriteRenderer>().sprite);



        }

    }

    public void reset()
    {

        oldPos = new Vector2(-8, -4);
        oldPosCom = new Vector2(-8, 4);
        foreach (Transform a in AObj.transform)
        {
            Destroy(a.gameObject);
        }
    }

    void SapXepBaiComputer()
    {
        for (int i = 0; i < 13; i++)
        {
            GameObject objCards = Instantiate(ComputerCards);
            int rd = Random.Range(0, Cards.Count - 1);
            objCards.transform.name = Cards[rd].name;
            //objCards.GetComponent<SpriteRenderer>().sprite = ;
            objCards.AddComponent<CardController>();
            objCards.AddComponent<BoxCollider2D>();
            objCards.transform.position = oldPosCom;
            oldPosCom += new Vector2(this.transform.position.x + objCards.GetComponent<SpriteRenderer>().bounds.size.x, 0);

            CardsComputer.Add(objCards);

            Cards.Remove(Cards[rd]);

        }
    }



    public bool CheckBoTrung(List<GameObject> lst)
    {
        for (int i = 0; i < lst.Count - 1; i++)
        {
            if (lst[i].GetComponent<CardController>().giaTri == lst[i + 1].GetComponent<CardController>().giaTri)
            {
                if (lst.Count > 2)
                {
                    return true;
                }
                else if (lst.Count == 2 && lst[i].GetComponent<CardController>().Kieuchat == lst[i + 1].GetComponent<CardController>().Kieuchat)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool CheckBoLienTiep(List<GameObject> lst)
    {
        if (lst.Count >= 3)
        {
            for (int j = 0; j < lst.Count - 1; j++)
            {
                for (int i = 0; i < lst.Count - 1; i++)
                {
                    int int1 = int.Parse(lst[i].GetComponent<CardController>().giaTri);
                    int int2 = int.Parse(lst[i + 1].GetComponent<CardController>().giaTri);
                    if (int1 > int2)
                    {
                        string oldInt;
                        oldInt = lst[i].GetComponent<CardController>().giaTri;
                        lst[i].GetComponent<CardController>().giaTri = lst[i + 1].GetComponent<CardController>().giaTri;
                        lst[i + 1].GetComponent<CardController>().giaTri = oldInt;
                    }
                }
            }
            foreach (var a in lst)
            {
                Debug.Log(a.GetComponent<CardController>().giaTri);
            }

            for (int i = 0; i < lst.Count - 1; i++)
            {
                int int1 = int.Parse(lst[i].GetComponent<CardController>().giaTri);
                int int2 = int.Parse(lst[i + 1].GetComponent<CardController>().giaTri);
                if (lst[i].GetComponent<CardController>().Kieuchat == lst[i + 1].GetComponent<CardController>().Kieuchat)
                {
                    Debug.Log("So 2 " + int2);
                    Debug.Log("So 1 " + int1);

                    Debug.Log("Check Bo: " + (int2 - int1));

                    if (int2 - int1 == 1)
                    {

                    }
                    else
                    {
                        return false;
                        break;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
        }
        return false;
    }
    public string Chat(GameObject Card)
    {
        string name = Card.GetComponent<SpriteRenderer>().sprite.ToString().Substring(2, 2);
        return name.Trim();

    }

    public string Giatri(GameObject Card)
    {
        string giatri = Card.GetComponent<SpriteRenderer>().sprite.ToString().Substring(0, 2);
        return giatri;
    }


}
