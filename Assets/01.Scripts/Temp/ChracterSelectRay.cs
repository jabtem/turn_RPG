﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChracterSelectRay : MonoBehaviour
{
    Ray ray;
    RaycastHit rayhit;

    GameObject PlayerCharacter;


    void Update()
    {

        //캐릭터만 인식하도록
        int layerMask = (1 << LayerMask.NameToLayer("Player"));



#if UNITY_EDITOR

 

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.blue);

        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayhit, 150f, layerMask))
            {


            }
        }

#endif

        //모바일 터치로직
#if (UNITY_ANDROID || UNITY_IPHONE)


        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out rayhit, 150f, layerMask))
                {
                    var objs = GameObject.FindObjectsOfType<SelectCharacterMove>();

                    foreach (var obj in objs)
                    {
                        obj.go = false;
                    }

                    SelectCharacterMove chracter = rayhit.collider.gameObject.GetComponent<SelectCharacterMove>();

                    chracter.go = true;

                    if (GameManager.instance != null)
                    {
                        GameManager.instance.CharacterNum = chracter.CharacterNum;
                    }

                }
            }
        }


#endif
    }


}
