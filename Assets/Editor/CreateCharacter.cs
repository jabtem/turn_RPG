﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CreateCharacter : ScriptableWizard
{
    // static 선언 안하면 에러
    private string str;
    static GameObject go;

    //게임오브젝트 생성허용 여부
    bool canCreate = true;
    public GameObject characterModel = null;
    static CreateCharacter window;
    //이전 캐릭터 모델
    GameObject preModel;

    [MenuItem("Create/Character")]
    static void Open()
    {
        window = DisplayWizard<CreateCharacter>("캐릭터 생성","생성","리셋");
        go = new GameObject("New Chracter");
        window.minSize = new Vector2(400, 400);//창 최소크기
       //EditorWindow.GetWindow(typeof(CreateCharacter));
    }



    protected override bool DrawWizardGUI()
    {
        GUILayout.Label("캐릭터 이름");
        str = EditorGUILayout.TextField(str);

        
        characterModel = (GameObject)EditorGUILayout.ObjectField(characterModel, typeof(GameObject), false);
        if(characterModel != null && canCreate)
        {

            characterModel = Instantiate(characterModel);

            //이전 캐릭터모델 저장, 에디터 조작하면서 모델을 변경해도 지장이없도록하기위함
            preModel = characterModel;
            //지정한 모델을 딱한번만 생성시키기 위함 
            canCreate = false;
            characterModel.transform.parent = go.transform;
        }

        //캐릭터 모델을 바꿔넣었을경우
        if(characterModel != null && preModel != characterModel)
        {
            GameObject.DestroyImmediate(preModel);
            canCreate = true;
        }

        
 

        return true;

    }

    private void OnWizardCreate()
    {

        if (str != null)
        {
            go.AddComponent<Player>();
            string prefabPath = "Assets/04.Prefabs/Character/" + str + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(go, prefabPath);
 
        }
        else
        {
            Debug.Log("프리펩 이름을 입력하세요");
        }


        GameObject.DestroyImmediate(go);
    }


    //리셋 버튼, ResetButton
    private void OnWizardOtherButton()
    {
        str = null;
        characterModel = null;
        GameObject.DestroyImmediate(go);
        GUI.FocusControl("리셋");
    }

    //에디터 창 닫을때 호출 생성한 빈게임오브젝트 제거
    private void OnDestroy()
    {
        GameObject.DestroyImmediate(go);
    }

    //void OnGUI()
    //{
    //    GUILayout.Label("프리펩 이름");
    //    str = EditorGUILayout.TextField(str);

    //    string prefabPath = "Assets/Prefabs/MyPrefabs/"+str+".prefab";
    //    if (GUILayout.Button("Create"))
    //    {
    //        PrefabUtility.SaveAsPrefabAsset(test, prefabPath);
    //    }
    //}
}
