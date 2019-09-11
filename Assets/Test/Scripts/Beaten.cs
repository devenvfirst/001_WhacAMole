using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地鼠被打击以后
/// </summary>
public class Beaten : MonoBehaviour
{
    /// <summary>
    /// 传入的洞口id
    /// </summary>
    public int id;

    /// <summary>
    /// 0.25s之后自动销毁被打的地鼠
    /// </summary>
    void Update()
    {
        Destroy(this.gameObject, 0.25f);     
    }

    /// <summary>
    /// 通知这个洞可以再次生成地鼠
    /// </summary>
    private void OnDestroy()
    {
        GameObject.FindObjectOfType<GameManager>().holes[id].isAppear = false;
    }
}
