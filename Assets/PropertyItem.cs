using UnityEngine;
using System.Collections;
using Regulus.Extension;

public class PropertyItem : MonoBehaviour 
{
    public static int _Priority;

    public int Priority { get; private set; }
    BladeAndSoulGossipCards.PROPERTY_TYPE _Type;
    public UnityEngine.UI.Text Name;
    public UnityEngine.UI.InputField Value;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Set(BladeAndSoulGossipCards.PROPERTY_TYPE type)
    {
        _Type = type;
        _SetName();
    }

    private void _SetName()
    {

        Name.text = string.Format("{0}({1})", _Type.GetEnumDescription() , Priority);
    }

    internal bool HasValue()
    {
        return Value.text.Length > 0;
    }

    public BladeAndSoulGossipCards.PROPERTY_TYPE Id { get { return _Type; } }

    internal int GetValue()
    {
        return int.Parse(Value.text);
    }

    public void OnChange()
    {
        Priority = ++_Priority;
        _SetName();
    }
}
