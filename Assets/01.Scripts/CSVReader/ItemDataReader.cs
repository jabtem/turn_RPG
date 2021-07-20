using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGInterface;

//아이템데이터 읽기용 
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
        //아이템데이터의 마지막열은 아이템 부과효과 설명이므로 따로 데이터로 넣진않는다
        int tableSize =(data.Length - 1) / line;

        items = new Item[tableSize];

        for(int i=0; i<tableSize; i++)
        {
            //첫행은 실제 데이터값이아닌 필드명칭이므로 제외하여 계산
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
            items[i].CRI = int.Parse(data[tableSize * (i + 1) + 14]);
            items[i].DELAY = int.Parse(data[tableSize * (i + 1) + 15]);
            items[i].TYPE = data[tableSize * (i + 1)+16];
            items[i].FireEn = int.Parse(data[tableSize * (i + 1) + 17]);
            items[i].WaterEn = int.Parse(data[tableSize * (i + 1) + 18]);
            items[i].EarthEn = int.Parse(data[tableSize * (i + 1) + 19]);
            items[i].LightEn = int.Parse(data[tableSize * (i + 1) + 20]);
            items[i].DarkEn = int.Parse(data[tableSize * (i + 1) + 21]);

            items[i].FireRES = int.Parse(data[tableSize * (i + 1) + 22]);
            items[i].WaterRES = int.Parse(data[tableSize * (i + 1) + 23]);
            items[i].EarthRES = int.Parse(data[tableSize * (i + 1) + 24]);
            items[i].LightRES = int.Parse(data[tableSize * (i + 1) + 25]);
            items[i].DarkRES = int.Parse(data[tableSize * (i + 1) + 26]);
        }
    }



}
