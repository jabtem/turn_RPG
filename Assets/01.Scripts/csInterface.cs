using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//추상클래스는 abstract 키워드를 지정한것만 재정의하지만
//인터페이스는 모든항목을 재정의해서 사용해야한다
namespace Interface2
{
    public interface IStudy
    {
        string Property_1 { get; }
        string Property_2 { set; }
        string Property_3 { get; set; }

        void Method();
        string Convert(string data);
    }

    public interface IPower
    {
        int Power
        {
            get;set;
        }
        void Method();
    }

    public interface IUserName : IPower
    {
        string UserName
        {
            get;set;
        }
    }

    public class PlayerState1 : IPower, IUserName
    {
        int _Power;
        string _UserName;

        bool man;

        public bool Man
        {
            get
            {
                return man;
            }
            set
            {
                man = value;
            }
        }

        public int Power
        {
            get
            {
                return _Power;
            }
            set
            {
                _Power = value;
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public void Method()
        {

        }
    }


    public class PlayerState2 : IUserName
    {
        int IPower;
        string _UserName;

        bool man;

        public PlayerState2(string name)
        {
            _UserName = name;
            Debug.Log(_UserName);
        }

        public bool Man
        {
            get 
            {
                return man;
            }
            set
            {
                man = value;
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        //이 프로퍼티를 사용 안할때
        public int Power { get; set; }

        public void Method()
        {

        }

    }

    //템플릿
    public interface Item<T>
    {
        void Method(T item);
    }

    public class ItemUse<T>  :Item<T>
    {
        private int item;
        public void Fct1(T item)
        {
            Debug.Log(item);
        }

        public void Method(T item)
        {
            Debug.Log(item);
        }
        public void Fct2()
        {
            //Method(item);
        }
    }
}

