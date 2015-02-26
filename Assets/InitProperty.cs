using UnityEngine;
using System.Collections;
using Regulus.Extension;
using System.Linq;
public class InitProperty : MonoBehaviour {

    public class Condition
    {

        public int Value { get; set; }

        public BladeAndSoulGossipCards.PROPERTY_TYPE Property { get; set; }
    }
    public RectTransform List;
    public GameObject PropertyEditPrefab;
    System.Collections.Generic.List<Condition> _Conditions;

    public Condition[] Conditions { get { return _Conditions.ToArray(); } }
	// Use this for initialization
	void Start () {
        _Conditions = new System.Collections.Generic.List<Condition>();
        foreach (BladeAndSoulGossipCards.PROPERTY_TYPE propertyType in System.Enum.GetValues(typeof(BladeAndSoulGossipCards.PROPERTY_TYPE)))
        {
            var desc = propertyType.GetEnumDescription();
            var instabce = GameObject.Instantiate(PropertyEditPrefab) as GameObject;
            instabce.transform.SetParent(List);
            instabce.transform.localScale = Vector3.one;
            
            var edit = instabce.GetComponent<PropertyEdit>();
            edit.SetName(desc, propertyType);
           /* edit.Enable.onValueChanged.AddListener((on) => 
            {
                if (on)
                    _Change(propertyType, int.Parse(edit.Value.text));
                else
                    _Remove(propertyType);
            });*/

            edit.Value.onEndEdit.AddListener((text) => 
            { 
                int val = 0;
                if (int.TryParse(text, out val))
                {
                    _Change(propertyType, val);
                }
                else
                    _Remove(propertyType);
                
            });
        }
	}

    private void _Remove(BladeAndSoulGossipCards.PROPERTY_TYPE propertyType)
    {
        var condition = _Find(propertyType);
        if (condition != null)
            _Conditions.Remove(condition);
    }

    private void _Change(BladeAndSoulGossipCards.PROPERTY_TYPE propertyType, int val)
    {
        Condition condition = _Query(propertyType);
        condition.Value = val;
    }

    private Condition _Query(BladeAndSoulGossipCards.PROPERTY_TYPE propertyType)
    {
        var condition = _Find(propertyType) ;
        if(condition == null)
            _Conditions.Add( new Condition { Property = propertyType , Value = 0});
        return _Find(propertyType);
    }

    private Condition _Find(BladeAndSoulGossipCards.PROPERTY_TYPE propertyType)
    {
        return (from c in _Conditions where c.Property == propertyType select c).FirstOrDefault();
    }

    
	
	// Update is called once per frame
	void Update () {
	
	}
}
