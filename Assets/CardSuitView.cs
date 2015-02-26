using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardSuitView : MonoBehaviour {

	// Use this for initialization
    public RectTransform List;
    public GameObject SuitLabelPrefab;
    public CardSuitView View;
    List<string> _Suits;

    public string[] Suits { get { return _Suits.ToArray(); } }

    public CardSuitView()
    {
        _Suits = new List<string>();
    }
	void Start () 
    {
        
	}

    public void AddSuit(string name)
    {
        var instance = GameObject.Instantiate(SuitLabelPrefab) as GameObject;
        instance.transform.SetParent(List);        
        var suit = instance.GetComponent<SuitLabel>();
        suit.SetName(name);

        var button = instance.GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => { _Change(suit); });
        
        instance.transform.localScale = Vector3.one;

        _Suits.Add(name);
    }

    private void _Change(SuitLabel suit)
    {
        View.AddSuit(suit.Name);
        suit.Remove();
        _Suits.Remove(suit.Name);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
