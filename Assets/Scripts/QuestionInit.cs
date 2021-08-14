using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestionInit : MonoBehaviour
{
    public QuestionManager questionManager;
    [SerializeField]
    private GameObject Element;
    [SerializeField]
    private GameObject ElementClone;

    public void Start()
    {
       int len = questionManager.Count * 2;
       for(int i=0;i<len; i++)
        {
            CreateObject(i);
        }
        StartCoroutine(EnableLayout());
    }

    public void CreateObject(int index1)
    {
        ElementClone = Instantiate(Element, this.transform);
        ElementClone.SetActive(true);
        ElementClone.GetComponent<Container>().Name = questionManager.QuestionPool[index1].Name;
        ElementClone.GetComponent<Container>().Data = questionManager.QuestionPool[index1].Data;
        ElementClone.GetComponentInChildren<TextMeshProUGUI>().text = (questionManager.QuestionPool[index1].Data).ToString();
        questionManager.totalElements++;

    }

    public IEnumerator EnableLayout()
    {
        yield return new WaitForSeconds(0.005f);
        GetComponent<FlowLayoutGroup>().enabled = true;
    }
}
