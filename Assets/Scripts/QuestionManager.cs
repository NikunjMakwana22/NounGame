using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Score;
    public GameObject NextLevelButton;
    public FlowLayoutGroup flg;
    public QuestionInit questionin;
    public GameObject ObjectPool;
    public GameObject Slot1, Slot2;
    public int score;
    public int totalElements, ElementsPlaced;
    public List<Items> Data;
    public QuestionContainer qc;
    public List<QuestionContainer> QuestionPool,temp;
    public int[] temp1,temp2;
    public int Count;
    private void Start()
    {
        QuestionPool.Clear();
        temp1 = GetRandomSequence2(Data[0].Data.Count, Count);
        foreach(int i in temp1)
        {
            qc = new QuestionContainer();
            qc.Name = Data[0].Name;
            qc.Data = Data[0].Data[i];
            QuestionPool.Add(qc);
        }
        temp2 = GetRandomSequence2(Data[1].Data.Count, Count);
        foreach (int i in temp2)
        {
            qc = new QuestionContainer();
            qc.Name = Data[1].Name;
            qc.Data = Data[1].Data[i];
            QuestionPool.Add(qc);
        }
        QuestionPool = QuestionPool.OrderBy(x => Random.value).ToList();
    }

    public void NextButton()
    {

        flg.enabled = false;
        foreach (Transform child in Slot1.transform)
            Destroy(child.gameObject);
        foreach (Transform child in Slot2.transform)
            Destroy(child.gameObject);
        foreach (Transform child in ObjectPool.transform)
            Destroy(child.gameObject);
        Start();
        int len = Count * 2;
        for (int i = 0; i < len; i++)
        {
            questionin.CreateObject(i);
        }
        StartCoroutine(questionin.EnableLayout());
        NextLevelButton.SetActive(false);
        Score.text = "0";
        score = 0;
    }

    
   


    public int[] GetRandomSequence2(int total, int n)
    {
        //Random total group
        int[] sequence = new int[total];
        //The length of the array of unique numbers obtained
        int[] output = new int[n];
        for (int i = 0; i < total; i++)
        {
            sequence[i] = i;
        }
        int end = total - 1;
        for (int i = 0; i < n; i++)
        {
            //A random number, every random time, random interval -1
            int num = Random.Range(0, end + 1);
            output[i] = sequence[num];
            //Assign the last number of the interval to the fetched number
            sequence[num] = sequence[end];
            end--;
            //Perform the effect once: 1, 2, 3, 4, 5 to 2
            //Then the next random interval becomes 1,5,3,4;
        }
        return output;
    }
}

[System.Serializable]
public class Items
{
    public string Name;
    public List<string> Data;
}

[System.Serializable]
public class QuestionContainer
{
    public string Name;
    public string Data;
}

