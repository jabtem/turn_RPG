using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGInterface;


public class ItemDataReader : MonoBehaviour
{
    public TextAsset itemData;

    public Item[] items;
    private void Start()
    {
        ReadCSV();
    }


    [ContextMenu("ReadCSV")]
    void ReadCSV()
    {
        string[] data = itemData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);//특정 문자를 기준으로 문자열 분할

        //실제 데이터 라인수 = 텍스트의 줄넘김 기준으로 문자열 분할했을때 데이터길이 -1
        //CSV데이터는 항상 값이 비어있는 라인이 하나 추가되어있음
        int line = itemData.text.Split('\n').Length - 1;

        // (전체 문자열수 / 행 개수) = 열 개수
        int tableSize = (data.Length - 1) / line;

        items = new Item[tableSize];

        for(int i=0; i<tableSize; i++)
        {
            items[i] = new Item();
            items[i].itemType = data[tableSize * (i + 1)];
            items[i].itemName = data[tableSize * (i + 1) + 1];
            items[i].itemId = data[tableSize * (i + 1) + 2];
            items[i].HP = int.Parse(data[tableSize * (i + 1) + 3]);
            items[i].MP = int.Parse(data[tableSize * (i + 1) + 4]);
            items[i].STR = int.Parse(data[tableSize * (i + 1) + 5]);
            items[i].AGI = int.Parse(data[tableSize * (i + 1) + 6]);
            items[i].DEX = int.Parse(data[tableSize * (i + 1) + 7]);
            items[i].INT = int.Parse(data[tableSize * (i + 1) + 8]);
            items[i].SPI = int.Parse(data[tableSize * (i + 1) + 9]);
            items[i].ATK = int.Parse(data[tableSize * (i + 1) + 10]);
            items[i].MTK = int.Parse(data[tableSize * (i + 1) + 11]);
            items[i].DEF = int.Parse(data[tableSize * (i + 1) + 12]);
            items[i].RES = int.Parse(data[tableSize * (i + 1) + 13]);
        }
    }



}
