using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCharacter : ScriptableWizard
{
    // static 선언 안하면 에러
    static string str;
    static GameObject go;

    [MenuItem("Create/Character")]
    static void CreateWindow()
    {
        DisplayWizard<CreateCharacter>("캐릭터 생성");
        go = new GameObject();
        //EditorWindow.GetWindow(typeof(CreateCharacter));
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

    protected override bool DrawWizardGUI()
    {
        GUILayout.Label("프리펩 이름");
        str = EditorGUILayout.TextField(str);
        return true;
    }

    private void OnWizardCreate()
    {
        string prefabPath = "Assets/04.Prefabs/Character/" + str +".prefab";
        PrefabUtility.SaveAsPrefabAsset(go, prefabPath);
        GameObject.DestroyImmediate(go);
    }
}
