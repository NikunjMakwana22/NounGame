using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler
{
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public bool Placed = false;
    private GameObject Parent;
    private int SiblingIndex;
   
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        Parent = transform.parent.gameObject;
        SiblingIndex = transform.GetSiblingIndex();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        transform.SetParent(canvas.transform);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
      
        if (!Placed)
        {
           
            this.transform.SetParent(Parent.transform);
        }
        else
            this.enabled = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
     
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
      
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (!Placed)
        {
          
            this.transform.SetParent(Parent.transform);
            this.transform.SetSiblingIndex(SiblingIndex);
        }
        else
            this.enabled = false;
        canvasGroup.blocksRaycasts = true;
    }
   
}
