using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoLuotScript : MonoBehaviour {

    public GameObject Desk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BtnClick()
    {
        BoLuot();
        Controller.Turn = 2;
    }

    public void BoLuot()
    {
        foreach(Transform a in Desk.transform)
        {
            Destroy(a.gameObject);
        }
        Controller.Turn = 1;
        Controller.thutuhabai = 0;
        Controller.CardOnDesk.Clear();
        Controller.CardComputerOnDesk.Clear();

        if(Controller.CardsPlayer.Count == 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Game_Over(true);
        }
        if(Controller.CardsComputer.Count == 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Game_Over(false);
        }
    }
}
