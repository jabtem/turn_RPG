using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//RPG 설계용 인터페이스 
namespace RPGInterface
{
    //스텟용 인터페이스
    public interface IStat
    {

        //체력
        int HP { get; set; }

        //마나
        int MP { get; set; }

        //힘
        int STR { get; set; }
        //민첩
        int AGI { get; set; }

        //재주
        int DEX { get; set; }

        //지능
        int INT { get; set; }

        //정신
        int SPI { get; set; }

        //물리공격력
        int ATK { get; set; }

        //마법공격력
        int MTK { get; set; }

        //물리방어력
        int DEF { get; set; }

        //마법저항력
        int RES { get; set; }

    }



    //아이템정보
    public interface IItem : IStat
    {
        //아이템종류
        string itemType { get; set; }

        //아이템명칭
        string itemName { get; set; }

        //아이템 고유ID
        string itemId { get; set; }
    }

    //면역속성
    public interface IImune
    {

        //물리면역
        bool physicalImmune { get; set; }

        //마법면역
        bool magicImmune { get; set; }
    }

    //아이템클래스 아이템데이터를위한클래스
    public class Item :IItem
    {


        string _itemType, _itemName, _itemId;

        int _HP,_MP,_STR,_AGI,_DEX,_INT,_SPI,_ATK,_MTK,_DEF,_RES;


        #region 아이템 속성
        public string itemType
        {
            get
            {
                return _itemType;
            }

            set
            {
                _itemType = value;
            }
        }
        public string itemName
        {
            get
            {
                return _itemName;
            }

            set
            {
                _itemName = value;
            }
        }
        public string itemId
        {
            get
            {
                return _itemId;
            }

            set
            {
                _itemId = value;
            }
        }


        public int HP 
        {
            get
            {
                return _HP;
            }

            set
            {
                _HP = value;
            }
        }
        public int MP
        {
            get
            {
                return _MP;
            }

            set
            {
                _MP = value;
            }
        }
        public int STR
        {
            get
            {
                return _STR;
            }

            set
            {
                _STR = value;
            }
        }
        public int AGI
        {
            get
            {     return _AGI;
            }

            set
            {
                _AGI = value;
            }
        }
        public int DEX
        {
            get
            {
                return _DEX;
            }

            set
            {
                _DEX = value;
            }
        }

        public int INT
        {
            get
            {
                return _INT;
            }

            set
            {
                _INT = value;
            }
        }
        public int SPI
        {
            get
            {
                return _SPI;
            }

            set
            {
                _SPI = value;
            }
        }
        public int ATK
        {
            get
            {
                return _ATK;
            }

            set
            {
                _ATK = value;
            }
        }

        public int MTK
        {
            get
            {
                return _MTK;
            }

            set
            {
                _MTK = value;
            }
        }
        public int DEF
        {
            get
            {
                return _DEF;
            }

            set
            {
                _DEF = value;
            }
        }
        public int RES
        {
            get
            {
                return _RES;
            }

            set
            {
                _RES = value;
            }
        }
        #endregion

    }

    //스탯클래스 플레이어와 몬스터 클래스의 부모클래스
    public class Stat : MonoBehaviour,IStat
    {
        //인스펙터 표시
        [SerializeField]
        int _HP, _MP, _STR, _AGI, _DEX, _INT, _SPI, _ATK, _MTK, _DEF, _RES;

        #region 스테이터스
        public int HP
        {
            get
            {
                return _HP;
            }

            set
            {
                _HP = value;
            }
        }
        public int MP
        {
            get
            {
                return _MP;
            }

            set
            {
                _MP = value;
            }
        }
        public int STR
        {
            get
            {
                return _STR;
            }

            set
            {
                _STR = value;
            }
        }
        public int AGI
        {
            get
            {
                return _AGI;
            }

            set
            {
                _AGI = value;
            }
        }
        public int DEX
        {
            get
            {
                return _DEX;
            }

            set
            {
                _DEX = value;
            }
        }

        public int INT
        {
            get
            {
                return _INT;
            }

            set
            {
                _INT = value;
            }
        }
        public int SPI
        {
            get
            {
                return _SPI;
            }

            set
            {
                _SPI = value;
            }
        }
        public int ATK
        {
            get
            {
                return _ATK;
            }

            set
            {
                _ATK = value;
            }
        }

        public int MTK
        {
            get
            {
                return _MTK;
            }

            set
            {
                _MTK = value;
            }
        }
        public int DEF
        {
            get
            {
                return _DEF;
            }

            set
            {
                _DEF = value;
            }
        }
        public int RES
        {
            get
            {
                return _RES;
            }

            set
            {
                _RES = value;
            }
        }
        #endregion


    }

}