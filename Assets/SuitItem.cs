using UnityEngine;
using System.Linq;
using System.Collections;
using Regulus.Extension;
using System.Collections.Generic;
public class SuitItem : MonoBehaviour 
{
    public UnityEngine.UI.Text PropertyDescription;
    public UnityEngine.UI.Text CardDescription;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Set(BladeAndSoulGossipCards.Suit suit)
    {
        List<string> propertys = new List<string>(); 
        propertys.Add(string.Format("{0} : {1}", "最大合成 ", _Max(suit.Cards)));
        foreach(var v in suit.Values)
        {
            var description = v.Id.GetEnumDescription();
            var value = v.Value;
            propertys.Add(string.Format("{0} : {1}",description , value ));
        }
        

        List<string> cards = new List<string>(); ;
        foreach (var card in suit.Cards)
        {
            cards.Add(string.Format("{0} : {1}", card.No, card.ToDescription()));            
        }


        PropertyDescription.text = string.Join("\n", propertys.ToArray());
        CardDescription.text = string.Join("\n", cards.ToArray());
    }

    private int _Max(BladeAndSoulGossipCards.Card[] cards)
    {
        return (from c in cards select c.MaxAppreciation).Sum();
    }
}
