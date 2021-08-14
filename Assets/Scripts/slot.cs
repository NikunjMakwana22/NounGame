using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class slot : MonoBehaviour,IDropHandler
{
    public QuestionManager QuestionManager;
    public TextMeshProUGUI Scoretext;
    public string Type;
    public GameObject NextLevelButton;
    public void OnDrop(PointerEventData eventData)
    {
       // Debug.Log("DropInSlot");
        eventData.pointerDrag.transform.SetParent(this.transform);
        if(eventData.pointerDrag.GetComponent<Container>().Name == Type)
        {
            eventData.pointerDrag.GetComponent<Image>().color = Color.green;
            eventData.pointerDrag.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
            eventData.pointerDrag.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.green;
            eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            QuestionManager.score += 5;
            Scoretext.text = QuestionManager.score.ToString();

        }
        else
        {
            eventData.pointerDrag.GetComponent<Image>().color = Color.red;
            eventData.pointerDrag.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
            eventData.pointerDrag.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.red;
            eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
        eventData.pointerDrag.GetComponent<DragDrop>().Placed = true;
        QuestionManager.ElementsPlaced++;

        if(QuestionManager.ElementsPlaced==QuestionManager.totalElements)
        {
            Debug.Log("Complete");
            NextLevelButton.SetActive(true);
        }
    }
}
