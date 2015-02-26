using UnityEngine;
using System.Collections;

public class LoadCardSuit : MonoBehaviour {

    public CardSuitView View;
	// Use this for initialization
	void Start () {
        foreach (var name in BladeAndSoulGossipCards.CardSet.Instance.GetSuitNames())
        {
            View.AddSuit(name);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
