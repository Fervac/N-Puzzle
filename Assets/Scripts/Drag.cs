using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
	Vector3 startPosition;
	private CanvasGroup canvasGroup;

	public bool posModifier = true;

	private void Awake()
    {
		//canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup = transform.parent.GetComponent<CanvasGroup>();
	}

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = .6f;
	}

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;
		canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1f;
		transform.position = startPosition;
	}

    // public void OnEndDrag(PointerEventData eventData)
	// {
	// 	itemBeingDragged = null;
	// 	canvasGroup.blocksRaycasts = true;
	// 	canvasGroup.alpha = 1f;
	// 	if (transform.parent == startParent)
	// 	{
	// 		transform.position = startPosition;
	// 	}
	// 	else
    //     {
	// 		Manager.Instance.gold -= price;

	// 		GameObject tmp = Instantiate(this.gameObject);
	// 		tmp.transform.position = startPosition;
	// 		tmp.transform.SetParent(startParent);

	// 		GetComponent<CanvasGroup>().blocksRaycasts = false;
	// 	}
	// }


	#endregion
}
