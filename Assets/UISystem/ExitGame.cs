using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // 実行ファイルで終了
        Application.Quit();

        // Unityエディタで実行中の確認（エディタ上では終了しないのでログを出す）
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}