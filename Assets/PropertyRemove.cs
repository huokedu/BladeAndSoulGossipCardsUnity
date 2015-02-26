using UnityEngine;
using System.Collections;

public class PropertyRemove : MonoBehaviour {

	// Use this for initialization
    public InitProperty Property;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Remove()
    {
        Core.Instance.SetPropertys(Property.Conditions);
        Core.Instance.ToResult();
        
        GameObject.DestroyObject(gameObject);
        
    }
}
