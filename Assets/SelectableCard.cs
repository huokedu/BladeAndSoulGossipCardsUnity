using UnityEngine;
using System.Collections;

public class SelectableCard : MonoBehaviour 
{
    BladeAndSoulGossipCards.Card _Card;
    public BladeAndSoulGossipCards.Card Card { get { return _Card; } }
    public UnityEngine.UI.Text Name;
    public UnityEngine.UI.Toggle Used;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Set(BladeAndSoulGossipCards.Card card,string name,bool used)
    {
        Used.isOn = used;
        Name.text = name;
        _Card = card;
    }

    public bool IsUsed 
    {
        get
        {
            return Used.isOn;
        }
    }
    
}
