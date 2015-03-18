using UnityEngine;
using System.Collections;
using System.Linq;

public class LoadCard : MonoBehaviour 
{
    public GameObject SelectableCard;
    public Transform SelectableCardRoot;
	// Use this for initialization
	void Start () {

        foreach(var card in Core.Instance.GetAllCards())
        {
            var instance = GameObject.Instantiate(SelectableCard);
            var selectableCard = instance.GetComponent<SelectableCard>();
            selectableCard.Set(card, card.No + ":" + card.ToDescription(), _Has(card));
            instance.transform.SetParent(SelectableCardRoot);
        }
	}

    private bool _Has(BladeAndSoulGossipCards.Card card)
    {
        return (from c in Core.Instance.Cards where c==card select c).Count() > 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Submit()
    {
        var cards = from c in SelectableCardRoot.gameObject.GetComponentsInChildren<SelectableCard>()
                    where c.IsUsed
                    select c.Card;

        Core.Instance.SetEnableCards(cards);

        Application.LoadLevel("PropertyFilter");
    }
}

