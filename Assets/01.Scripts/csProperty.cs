using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CCC
{

}
public class csProperty : MonoBehaviour
{
    private int health = 30;


    //Property
    public int Health
    {
        get
        {
            return health;
        }
        private set
        {
            health = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        print(Health);
        Health = 50;
        print(Health);



        //(cf) MonoBehaviour 이거 때문에 null 나온다...
        csCsharpStudy aaa = new csCsharpStudy();
        Debug.Log(aaa);

        // 마찬가지
        csProperty bbb = new csProperty();
        Debug.Log(bbb);

        CCC ccc = new CCC();
        Debug.Log(ccc);


    }
}
