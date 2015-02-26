using UnityEngine;
using System.Collections;

public class SuitRemove : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Remove()
    {
        var useds = GetComponentInChildren<UsedSuit>();
        Core.Instance.SetSuits(useds.Suits);
        Core.Instance.ToPropertyFilter();
        GameObject.DestroyObject(gameObject);        
    }
}
