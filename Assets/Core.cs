﻿using UnityEngine;
using System.Collections;
using System.Linq;
using BladeAndSoulGossipCards;
using BladeAndSoulGossipCards.Extend;
using System.Collections.Generic;
public class Core : MonoBehaviour 
{
    public GameObject PropertyFilter;
    public GameObject SuitFilter;
    public GameObject Result;
    public TextAsset Data;
    void Awake()
    {
        BladeAndSoulGossipCards.CardSet.Instance.Build(Data.text);
    }
	// Use this for initialization
	void Start () 
    {
        ToSuitFilter();
	}

    private void ToSuitFilter()
    {
        var instance = GameObject.Instantiate(SuitFilter) as GameObject;
        instance.transform.localScale = Vector3.one;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToPropertyFilter()
    {
        var instance = GameObject.Instantiate(PropertyFilter) as GameObject;
        instance.transform.localScale = Vector3.one;
    }

    static public Core Instance 
    {
        get {
            return GameObject.FindObjectOfType<Core>();
        }
    }
    string[] _Suits;
    private InitProperty.Condition[] _Conditions;
    internal void SetSuits(string[] suits)
    {
        _Suits = suits;
    }

    internal void SetPropertys(InitProperty.Condition[] condition)
    {
        _Conditions = condition;
    }

    internal void ToResult()
    {
        var instance = GameObject.Instantiate(Result) as GameObject;
        instance.transform.localScale = Vector3.one;
    }

    internal void QueryResult(System.Action<Suit[]> suit_callback)
    {
        StartCoroutine(_QueryResult(suit_callback));
    }

    IEnumerator _QueryResult(System.Action<Suit[]> suit_callback)
    {
        var propertyValues = (from c in _Conditions select new BladeAndSoulGossipCards.PropertyValue { Id = c.Property, Value = c.Value }).ToArray();

        BladeAndSoulGossipCards.CardSet set = BladeAndSoulGossipCards.CardSet.Instance;
        var cards = set.Find(propertyValues, _Suits);

        Card[] cards1 = cards.Assort(1).Fill(CardSet.Instance, 1);
        Card[] cards2 = cards.Assort(2).Fill(CardSet.Instance, 2);
        Card[] cards3 = cards.Assort(3).Fill(CardSet.Instance, 3);
        Card[] cards4 = cards.Assort(4).Fill(CardSet.Instance, 4);
        Card[] cards5 = cards.Assort(5).Fill(CardSet.Instance, 5);
        Card[] cards6 = cards.Assort(6).Fill(CardSet.Instance, 6);
        Card[] cards7 = cards.Assort(7).Fill(CardSet.Instance, 7);
        Card[] cards8 = cards.Assort(8).Fill(CardSet.Instance, 8);
        Regulus.Utility.TimeCounter timeCounter = new Regulus.Utility.TimeCounter();
        List<Suit> suits = new List<Suit>();
        System.Int64 total = cards1.Count() * cards2.Count() * cards3.Count() * cards4.Count() * cards5.Count() * cards6.Count() * cards7.Count() * cards8.Count();
        int count = 0;
        Property[] propertys = propertyValues.ToArray();
        foreach (var card1 in cards1)
            foreach (var card2 in cards2)
                foreach (var card3 in cards3)
                    foreach (var card4 in cards4)
                        foreach (var card5 in cards5)
                            foreach (var card6 in cards6)
                                foreach (var card7 in cards7)
                                    foreach (var card8 in cards8)
                                    {
                                        if (timeCounter.Second > 1)
                                        {
                                            

                                            timeCounter.Reset();

                                            var orders = suits.OrderBy((suit) => suit.GetValue(propertys[0]));
                                            foreach (var property in propertys.Skip(1))
                                            {
                                                orders = orders.ThenBy((suit) => suit.GetValue(property));
                                            }

                                            suits = orders.ToList();

                                            if (suits.Count > 100)
                                                suits.RemoveRange(0, suits.Count - 100);

                                        }

                                        var s = new Suit(card1, card2, card3, card4, card5, card6, card7, card8);

                                        bool pass = (from filter in propertyValues
                                                     where s.GetValue(filter) < filter.Value
                                                     select false).Count() == 0;

                                        if (pass)
                                            suits.Add(s);
                                        count++;
                                        yield return new WaitForEndOfFrame();
                                    }
        var result = suits.OrderByDescending((suit) => suit.GetValue(propertys[0]));
        foreach (var property in propertys.Skip(1))
        {
            result = result.ThenByDescending((suit) => suit.GetValue(property));
        }
        

        suit_callback(result.ToArray());

        yield return new WaitForEndOfFrame() ;
    }

    private void _BuildResultLabel(List<Suit> suits)
    {
        
    }


}
