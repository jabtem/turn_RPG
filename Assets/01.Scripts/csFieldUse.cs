using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Field;
public class csFieldUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //네임스페이스 없을때
        //Field.Armor aromor = new Field.Armor;

        Armor armor = new Armor();

        armor.name = "블랙 드라곤";

        Man man = new Man();
        man._Name = "우상준";

        Debug.Log(string.Format("이름 : {0}, 갑옷 : {1}, 디펜스 : {2}, 색상 : {3}", man._Name, armor.name, Armor.m_defence, Armor._Color));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
