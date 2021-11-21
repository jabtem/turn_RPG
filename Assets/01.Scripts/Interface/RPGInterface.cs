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

        int CRI { get; set; }

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

        //장비 공격딜레이
        int DELAY { get; set; }

        //아이템 세부분류
        string TYPE { get; set; }


        //속성강화
        int FireEn { get; set; }
        int WaterEn { get; set; }
        int EarthEn { get; set; }
        int LightEn { get; set; }
        int DarkEn { get; set; }

        //속성저항
        int FireRES { get; set; }
        int WaterRES { get; set; }
        int EarthRES { get; set; }
        int LightRES { get; set; }
        int DarkRES { get; set; }

        //부가효과
        string SideEffect { get; set; }

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
    [System.Serializable]
    public class Item :IItem
    {

        [SerializeField]
        //아이템분류
        string _itemName, _itemId, _itemType;
        [SerializeField]
        int _HP,_MP,_STR,_AGI,_DEX,_INT,_SPI,_ATK,_MTK,_DEF,_RES;

        //치명타율 ,공격딜레이, 장비분류
        [SerializeField]
        int _CRI, _DELAY;

        [SerializeField]
        //장비 세부분류
        string _TYPE;


        [SerializeField]
        //속성강화수치
        int _FireEn, _WaterEn, _EarthEn, _LightEn, _DarkEn;

        [SerializeField]
        //속성저항수치
        int _FireRES, _WaterRES, _EarthRES, _LightRES, _DarkRES;

        [SerializeField]
        string _SideEffect;

        #region 아이템 속성
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

        public int CRI
        {
            get
            {
                return _CRI;
            }

            set
            {
                _CRI = value;
            }
        }
        public int DELAY
        {
            get
            {
                return _DELAY;
            }

            set
            {
                _DELAY = value;
            }
        }

        public string TYPE
        {
            get
            {
                return _TYPE;
            }

            set
            {
                _TYPE = value;
            }
        }
        public int FireEn
        {
            get
            {
                return _FireEn;
            }

            set
            {
                _FireEn = value;
            }
        }
        public int WaterEn
        {
            get
            {
                return _WaterEn;
            }

            set
            {
                _WaterEn = value;
            }
        }
        public int EarthEn
        {
            get
            {
                return _EarthEn;
            }

            set
            {
                _EarthEn = value;
            }
        }
        public int LightEn
        {
            get
            {
                return _LightEn;
            }

            set
            {
                _LightEn = value;
            }
        }
        public int DarkEn
        {
            get
            {
                return _DarkEn;
            }

            set
            {
                _DarkEn = value;
            }
        }

        public int FireRES
        {
            get
            {
                return _FireRES;
            }

            set
            {
                _FireRES = value;
            }
        }
        public int WaterRES
        {
            get
            {
                return _WaterRES;
            }

            set
            {
                _WaterRES = value;
            }
        }
        public int EarthRES
        {
            get
            {
                return _EarthRES;
            }

            set
            {
                _EarthRES = value;
            }
        }
        public int LightRES
        {
            get
            {
                return _LightRES;
            }

            set
            {
                _LightRES = value;
            }
        }
        public int DarkRES
        {
            get
            {
                return _DarkRES;
            }

            set
            {
                _DarkRES = value;
            }
        }

        public string SideEffect 
        { 
            get
            {
                return _SideEffect;
            }
            set
            {
                _SideEffect = value;
            }
        
        }

        #endregion

    }

    //스탯클래스 플레이어와 몬스터 클래스의 부모클래스
    public class Stat : MonoBehaviour,IStat
    {
        //인스펙터 표시
        [SerializeField]
        int _HP, _MP, _STR, _AGI, _DEX, _INT, _SPI, _ATK, _MTK, _DEF, _RES, _CRI;

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

        public int CRI
        {
            get
            {
                return _CRI;
            }

            set
            {
                _CRI = value;
            }
        }
        #endregion


    }

}