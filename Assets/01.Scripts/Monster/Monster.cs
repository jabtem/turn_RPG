using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGInterface;

public class Monster : Stat,IImune
{
    [SerializeField]
    bool _physicalImmune, _magicImmune;

    #region 면역유무
    //물리면역
    public bool physicalImmune
    {
        get
        {
            return _physicalImmune;
        }
        set
        {
            _physicalImmune = value;
        }
    }

    //마법면역
    public bool magicImmune
    {
        get
        {
            return _magicImmune;
        }
        set
        {
            _magicImmune = value;
        }
    }
    #endregion
}
