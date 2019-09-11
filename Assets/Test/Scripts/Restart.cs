using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// 重新开始按钮
/// </summary>
public class Restart : MonoBehaviour {

    /// <summary>
    /// 要绑定的事件
    /// </summary>
    public void OnMouseDown()
    {
        //重新加载游戏场景
        EditorSceneManager.LoadScene("Main");
    }
}
