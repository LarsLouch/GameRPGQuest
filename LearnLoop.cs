using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    private void Start()
    {
        // 當布林值為 true 時執行一次
        if (true)
        {
            print("我是判斷式!");
        }

        // 迴圈 While
        // 重複處理相同程式
        // 當布林值為 true 時持續執行
        int a = 1;

        while (a <= 10)
        {
            print("我是迴圈 while!!! 迴圈次數：" + a);
            a++;
        }

        // 迴圈 for
        // (初始值；條件；迭代器 - 初始值增減)
        for (int x = 1; x <= 10; x++)
        {
            print("我是迴圈 for!!! 迴圈次數：" + x);
        }

        // 延伸學習
        // do while、foreach、
    }
}
