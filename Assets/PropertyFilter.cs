using UnityEngine;
using System.Collections;
using System.Linq;
public class PropertyFilter : MonoBehaviour 
{
    public Transform PropertyRoot;
    public GameObject Property;
	// Use this for initialization
	void Start () 
    {
	    foreach(var type in Core.Instance.GetPropertys())
        {
            var instance = GameObject.Instantiate(Property);
            var item = instance.GetComponent<PropertyItem>();
            item.Set(type);

            instance.transform.SetParent( PropertyRoot);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Submit()
    {
        var propertys = from item in PropertyRoot.GetComponentsInChildren<PropertyItem>()
                        where item.HasValue()
                        orderby item.Priority descending
                        select new BladeAndSoulGossipCards.PropertyValue { Id = item.Id, Value = item.GetValue() };
        Core.Instance.SetPropertys(propertys.ToArray());

        Application.LoadLevel("CalculationSuit");
    }
}
