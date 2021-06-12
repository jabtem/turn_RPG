using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//RPG 설계용 인터페이스 
namespace RPGInterface
{
    //스텟용 인터페이스
    public interface IStat
    {

        //체력
        int healthPoint { get; set; }

        //마나
        int manaPoint { get; set; }

        //힘
        int strength { get; set; }
        //민첩
        int agility { get; set; }

        //재주
        int dexterity { get; set; }

        //지능
        int intelligence { get; set; }

        //정신
        int spirit { get; set; }

        //물리공격력
        int attackPower { get; set; }

        //마법공격력
        int magicPower { get; set; }

        //물리방어력
        int defense { get; set; }

        //마법저항력
        int resitance { get; set; }

    }


    public interface IItem : IStat
    {
        //아이템종류
        string type { get; set; }

        //아이템명칭
        string name { get; set; }

        //아이템 고유ID
        string id { get; set; }
    }

    public class item : IItem, IStat
    {
        public string type { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int healthPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int manaPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int strength { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int agility { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int dexterity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int intelligence { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int spirit { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int attackPower { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int magicPower { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int defense { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int resitance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}