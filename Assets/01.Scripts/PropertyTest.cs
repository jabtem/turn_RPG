using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTest : MonoBehaviour
{

    //Property
    public int Health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        print(Health);
        Health = 50;
        print(Health);

    }
}
