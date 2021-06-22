using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    //타일 속성

    [SerializeField]
    bool _FIRE, _WATER, _EARTH, _LIGHT, _DARKNESS;

    #region 타일 원소속성
    public bool FIRE
    {
        get
        {
            return _FIRE;
        }
        set
        {
            _FIRE = value;
        }
    }

    public bool WATER
    {
        get
        {
            return _WATER;
        }
        set
        {
            _WATER = value;
        }
    }

    public bool EARTH
    {
        get
        {
            return _EARTH;
        }
        set
        {
            _EARTH = value;
        }
    }

    public bool LIGHT
    {
        get
        {
            return _LIGHT;
        }
        set
        {
            _LIGHT = value;
        }
    }

    public bool DARKNESS
    {
        get
        {
            return _DARKNESS;
        }
        set
        {
            _DARKNESS = value;
        }
    }
    #endregion
}
