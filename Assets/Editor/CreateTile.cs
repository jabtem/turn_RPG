using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MAST.Component;

public class CreateTile : EditorWindow
{
    // static 선언 안하면 에러
    private string str;
    static GameObject go = null;
    static EditorWindow window;

    //이전 타일 모델
    GameObject preModel = null;

    [MenuItem("Create/Tile")]
    static void Open()
    {
        window = EditorWindow.GetWindow(typeof(CreateTile));
        window.minSize = new Vector2(400, 400);//창 최소크기
    }
    void OnGUI()
    {
        GUILayout.Label("타일 이름");
        str = EditorGUILayout.TextField(str);

        GUILayout.Label("타일 모델");
        go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), false);

        if(go !=null && preModel == null)
        {
            go = Instantiate(go);
            preModel = go;
        }
        //모델 교체시 기존모델 삭제
        else if(go !=null && preModel != go)
        {
            GameObject.DestroyImmediate(preModel);
        }

        //이름, 모델 둘중하나만 비어있어도 생성 비활성
        if (str != null &&  go != null)
        {
            GUI.enabled = true;
        }
        else
        {
            EditorGUILayout.HelpBox("타일 이름이 없거나 모델이 등록되지 않았습니다.", MessageType.Error);
            GUI.enabled = false;
        }

        if (GUILayout.Button("Create"))
        {
            GUI.enabled = true;
            go.AddComponent<MASTPrefabSettings>();
            go.AddComponent<MeshCollider>();
            string prefabPath = "Assets/04.Prefabs/Tile/" + str + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(go, prefabPath);
            //생성후 에디터창 종료
            window.Close();
        }
    }
    private void OnDestroy()
    {
        GameObject.DestroyImmediate(go);
    }
}
