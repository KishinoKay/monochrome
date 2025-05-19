using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // シーン名で切り替える場合
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}