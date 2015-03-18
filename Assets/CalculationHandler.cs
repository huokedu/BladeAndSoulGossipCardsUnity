using UnityEngine;
using System.Collections;

public class CalculationHandler : MonoBehaviour 
{
    public Transform SuitItemRoot;
    public GameObject SuitItem;
    public UnityEngine.UI.Text Message;
    public UnityEngine.UI.Button SubmitButton;
	// Use this for initialization
	void Start () 
    {
        SubmitButton.gameObject.SetActive(false);
        Core.Instance.QueryResult(_Done);
        
	}

    private void _Done(BladeAndSoulGossipCards.Suit[] obj)
    {
        SubmitButton.gameObject.SetActive(true);
        StartCoroutine(_Build(obj));
    }

    private IEnumerator _Build(BladeAndSoulGossipCards.Suit[] suits)
    {
        foreach(var suit in suits)
        {
            var ins = GameObject.Instantiate(SuitItem);
            var item = ins.GetComponent<SuitItem>();
            item.Set(suit);

            ins.transform.SetParent( SuitItemRoot);
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
	
	// Update is called once per frame
	void Update () 
    {
        Message.text = string.Format("{0}/{1}", Core.Instance.CalculationCount, Core.Instance.CalculationAmount);
	}


    public void Submit()
    {
        Application.LoadLevel("CardSelector");
    }
}
