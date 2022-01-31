using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 選單管理：開始遊戲、載入遊戲、離開遊戲
/// </summary>
public class MenuManager : MonoBehaviour
{
    [Header("載入畫面")]
    public GameObject panel;
    [Header("載入進度")]
    public Text textLoading;
    [Header("載入吧條")]
    public Image imgLoading;
    [Header("提示文字")]
    public Text textTip;

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); // 應用程式.離開()
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        StartCoroutine(Loading());      // 啟動協程
    }

    /// <summary>
    /// 載入場景功能
    /// </summary>
    private IEnumerator Loading()
    {
        panel.SetActive(true);                                          // 啟動設定(布林值) - true 顯示、false 隱藏
        AsyncOperation ao = SceneManager.LoadSceneAsync("遊戲場景");     // 非同步載入資訊 = 場景管理器.非同步載入("場景名稱")
        ao.allowSceneActivation = false;                                // 載入資訊.允許自動載入 = 否 - 不允許自動載入

        // ao.isDone == true  簡寫 ao.isDone
        // ao.isDone == false 簡寫 !ao.isDone
        // 當 載入資訊.完成 為 false - 尚未載入完成時執行迴圈
        while (!ao.isDone)
        {
            // progress 載入場景的進度值為 0 - 1，如果設定 allow 為 false 會卡在 0.9
            // ToString("F小數點位數")：小數點兩位 F2、小數點零位 F0 - F 大小寫皆可
            textLoading.text = "載入進度：" + (ao.progress / 0.9f * 100).ToString("F2") + "%";   // 載入文字 = "載入進度" + ao.進度 * 100 + "%"
            imgLoading.fillAmount = ao.progress / 0.9f;                                         // 載入吧條 = ao.進度
            yield return null;

            if (ao.progress == 0.9f)                                                            // 如果 ao.進度 等於 0.9
            {
                textTip.enabled = true;                                                         // 提示文字.啟動 = 是 - 顯示提示文字

                if (Input.anyKeyDown) ao.allowSceneActivation = true;                           // 如果 按下任意鍵 允許自動載入
            }
        }
    }
}
