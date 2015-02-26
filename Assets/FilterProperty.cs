using UnityEngine;
using System.Collections;

public class FilterProperty : MonoBehaviour {

	// Use this for initialization
    public CardSuitView View;
    public RectTransform RemoveRoot;
    public GameObject InstanceRootPrefab;
	void Start () 
    {
	
	}
	

    public void ToFilterProperty()
    {
        var instance = GameObject.Instantiate(InstanceRootPrefab) as GameObject;
        instance.transform.localScale = Vector3.one;
        GameObject.DestroyObject(RemoveRoot);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
