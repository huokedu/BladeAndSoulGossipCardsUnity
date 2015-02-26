using UnityEngine;
using System.Collections;

public class PropertyEdit : MonoBehaviour {

    public UnityEngine.UI.Text Name;
    public UnityEngine.UI.InputField Value;    
    BladeAndSoulGossipCards.PROPERTY_TYPE _Type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void SetName(string desc, BladeAndSoulGossipCards.PROPERTY_TYPE propertyType)
    {
        _Type = propertyType;
        Name.text = desc;
    }
}
