using UnityEngine;
using System.Collections;

public class BuildResultLabel : MonoBehaviour {

	// Use this for initialization
    public GameObject ResultLabelPrefab;
	void Start () {

        Core.Instance.QueryResult( _Result  );
	}

    private void _Result(BladeAndSoulGossipCards.Suit[] suits)
    {
        foreach(var suit in suits)
        {
            var instance = GameObject.Instantiate(ResultLabelPrefab) as GameObject;
            //var label = instance.GetComponent<ResultLabel>();
            //label.Set(suit);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
