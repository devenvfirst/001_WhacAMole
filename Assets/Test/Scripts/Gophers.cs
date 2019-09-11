using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 地鼠类
/// </summary>
public class Gophers : MonoBehaviour {

    /// <summary>
    /// 预制体资源
    /// </summary>
    public GameObject beaten;

    /// <summary>
    /// 传入的洞口的id
    /// </summary>
    public int id;

    private void Update()
    {
        Destroy(this.gameObject,3.0f);
    }


    /// <summary>
    /// 鼠标点击地鼠时
    /// </summary>
    private void OnMouseDown()
    {
        GameObject g;
        g = Instantiate(beaten,transform.position,Quaternion.identity);
        g.GetComponent<Beaten>().id = id;
        FindObjectOfType<GameManager>().AddScore();
        Destroy(this.gameObject, 0.1f);
    }

    /// <summary>
    /// 地鼠销毁时，通知这个洞可以再生成地鼠
    /// </summary>
    private void OnDestroy()
    {
        FindObjectOfType<GameManager>().holes[id].isAppear = false;
    }
}
