using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaBaiScript : MonoBehaviour {
    Vector2 RandomPos;
    GameObject controller;
    static List<GameObject> cardsChoose;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("Game_Controller");
        
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HaBai()
    {
        cardsChoose = new List<GameObject>();
        foreach (var a in Controller.CardChoose)
        {
            cardsChoose.Add(a);
            
        }       

        
     

        bool checkBoLienTiep;
        bool checkBoTrung;

        
        checkBoLienTiep = controller.GetComponent<Controller>().CheckBoLienTiep(cardsChoose);
        checkBoTrung = controller.GetComponent<Controller>().CheckBoTrung(cardsChoose);
        Debug.Log("CheckBoLienTiep: " + checkBoLienTiep);
        if (cardsChoose.Count >= 2)
        {
            if (checkBoLienTiep || checkBoTrung)
            {
                Debug.Log("Check Bo Ok");
                MoveCard(cardsChoose);
            }
            else
            {
                Debug.Log("Check Bo False");
            }
        }
        else
        {
            MoveCard(cardsChoose);
        }


    }

    void MoveCard(List<GameObject> lst)
    {
        
        foreach(var a in lst)
        {
            Vector2 vt = SetRandomVector();
            a.transform.localPosition = vt; 
            a.transform.Translate(vt * Time.deltaTime) ;
        }
        Controller.CardChoose.Clear();
    }

    Vector2 SetRandomVector()
    {
        float RandomX;
        float RandomY;
        RandomX = Random.Range(-2, 2);
        Debug.Log("Random x"+RandomX);
        RandomY = Random.Range(6, 8);
        Debug.Log("Random y"+RandomY);
        RandomPos = new Vector2(RandomX, RandomY);
        return RandomPos;
    }
}
