using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface2;
public class csInterfaceUse : MonoBehaviour
{
    IUserName playerState;
    IUserName UserName;
    ItemUse<int> item;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = new PlayerState2("WooPro");
        Debug.Log(playerState.UserName);

        item = new ItemUse<int>();
        item.Fct1(5);
        item.Method(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
