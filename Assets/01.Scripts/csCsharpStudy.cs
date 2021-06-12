using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCsharpStudy : MonoBehaviour
{
    // Start is called before the first frame update
    public int Value1, Value2;

    [System.Serializable]
    public class Item1
    {
        private int m_amount;
        public int GetAmount()
        {
            return m_amount;
        }
        public void SetAmount(int num)
        {
            m_amount = num;
        }
    }
    [System.Serializable]
    public class Item2
    {
        private int m_amount;
        public int Num
        { 
            get 
            {
                Debug.Log(2);
                return m_amount;
            } 
            set 
            {
                Debug.Log(1);
                m_amount = value;
            } 
        }
    }

    public Item1 item1;
    public Item2 item2;

    void Start()
    {
        item1.SetAmount(5);
        Value1 = item1.GetAmount();

        item2.Num = 22;//set
        Value2 = item2.Num;//get



        //Debug.Log(string.Format("decimal {0}  info {1} ~ {2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue));

        //Debug.Log(string.Format("ulong {0}  info {1} ~ {2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue));

        //Debug.Log(string.Format("long {0}  info {1} ~ {2}", sizeof(long), long.MinValue, long.MaxValue));

        //Debug.Log(string.Format("float {0}  info {1} ~ {2}", sizeof(float), float.MinValue, float.MaxValue));

        //Debug.Log(string.Format("int {0}  info {1} ~ {2}", sizeof(int), int.MinValue, int.MaxValue));

        //Debug.Log(string.Format("char {0}  info {1} ~ {2}", sizeof(char), char.MinValue, char.MaxValue));

        //Debug.Log(string.Format("byte {0}  info {1} ~ {2}", sizeof(byte), byte.MinValue, byte.MaxValue));

        //Debug.Log(string.Format("sbyte {0}  info {1} ~ {2}", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
    }

}
