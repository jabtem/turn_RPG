using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    Ray ray;
    RaycastHit rayhit;
    public PlayerCtrl player;

    public bool menuOpen;
    int layerMask;

    private void Start()
    {
        layerMask = (1 << LayerMask.NameToLayer("Player"));
    }

    private void Update()
    {
#if UNITY_EDITOR



        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(rayhit);


        if (Input.GetMouseButtonDown(0) && menuOpen)
        {
            Debug.Log(Physics.Raycast(ray, out rayhit, 100.0f, layerMask));
            if (Physics.Raycast(ray, out rayhit, 100.0f, layerMask))
            {
                Debug.Log(rayhit.collider.gameObject);
                rayhit.collider.gameObject.TryGetComponent<PlayerCtrl>(out player);
                player.isSelected = true;

            }
        }

#endif
    }
}
