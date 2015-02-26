using UnityEngine;
using System.Collections;

public class SuitLabel : MonoBehaviour {

    public UnityEngine.UI.Text Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void SetName(string name)
    {
        Text.text = name;
        
    }

    public string Name { get { return Text.text; } }

    internal void Remove()
    {
        GameObject.DestroyObject(gameObject);
    }
}
