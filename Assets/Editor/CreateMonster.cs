using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CreateMonster : ScriptableWizard
{
    // static 선언 안하면 에러
    string str;
    int HP, MP, STR, AGI, DEX, INT, SPI, ATK, MTK, DEF, RES;
    static GameObject go;

    //게임오브젝트 생성허용 여부
    bool canCreate = true;
    static GameObject monsterModel = null;
    static CreateMonster window;
    //이전 캐릭터 모델
    GameObject preModel;

    [MenuItem("Create/Monster")]
    static void Open()
    {
        window = DisplayWizard<CreateMonster>("몬스터 생성", "생성", "리셋");
        go = new GameObject("New Monster");
        window.minSize = new Vector2(400, 400);//창 최소크기
                                               //EditorWindow.GetWindow(typeof(CreateCharacter));
    }



    protected override bool DrawWizardGUI()
    {
        GUILayout.Label("몬스터 이름");
        str = EditorGUILayout.TextField(str);
        GUILayout.Space(20);

        GUILayout.Label("몬스터 모델");
        monsterModel = (GameObject)EditorGUILayout.ObjectField(monsterModel, typeof(GameObject), false);
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        GUILayout.Label("HP");
        HP = EditorGUILayout.IntField(HP);
        GUILayout.Label("MP");
        MP = EditorGUILayout.IntField(MP);
        GUILayout.EndHorizontal();
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        GUILayout.Label("STR");
        STR = EditorGUILayout.IntField(STR);
        GUILayout.Label("AGI");
        AGI = EditorGUILayout.IntField(AGI);
        GUILayout.Label("DEX");
        DEX = EditorGUILayout.IntField(DEX);
        GUILayout.Label("INT");
        INT = EditorGUILayout.IntField(INT);
        GUILayout.Label("SPI");
        SPI = EditorGUILayout.IntField(SPI);
        GUILayout.EndHorizontal();
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        GUILayout.Label("물리 공격력");
        ATK = EditorGUILayout.IntField(ATK);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("마법 공격력");
        MTK = EditorGUILayout.IntField(MTK);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("물리 방어력");
        DEF = EditorGUILayout.IntField(DEF);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("마법 저항력");
        RES = EditorGUILayout.IntField(RES);
        GUILayout.EndHorizontal();


        if (monsterModel != null && canCreate)
        {

            monsterModel = Instantiate(monsterModel);

            //이전 캐릭터모델 저장, 에디터 조작하면서 모델을 변경해도 지장이없도록하기위함
            preModel = monsterModel;
            //지정한 모델을 딱한번만 생성시키기 위함 
            canCreate = false;
            monsterModel.transform.parent = go.transform;
        }

        //캐릭터 모델을 바꿔넣었을경우
        if (monsterModel != null && preModel != monsterModel)
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
            go.AddComponent<Monster>();
            Monster m = go.GetComponent<Monster>();
            m.HP = HP;
            m.MP = MP;
            m.STR = STR;
            m.AGI = AGI;
            m.DEX = DEX;
            m.INT = INT;
            m.SPI = SPI;
            m.ATK = ATK;
            m.MTK = MTK;
            m.DEF = DEF;
            m.RES = RES;

            string prefabPath = "Assets/04.Prefabs/Monster/" + str + ".prefab";
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
        monsterModel = null;
        HP = MP = STR = AGI = DEX = INT = SPI = ATK = MTK = DEF = RES = 0;
        GameObject.DestroyImmediate(preModel);
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
