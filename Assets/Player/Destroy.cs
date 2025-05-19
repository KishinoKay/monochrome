using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Destroy : MonoBehaviour
{
    public ParticleSystem destroyEffect;
    public ParticleSystem TrajectoryParticle;
    public string nextSceneName;

    public void DestroyWithEffect()
    {
        // パーティクルを生成して再生
        var effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        effect.Play();

        // 自分自身を非表示にして破壊演出中に見えないようにする
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        TrajectoryParticle.GetComponent<Renderer>().enabled = false;

        // パーティクルの再生完了を待ってシーンを切り替える
        StartCoroutine(WaitForParticleAndLoadScene(effect));
    }

    private IEnumerator WaitForParticleAndLoadScene(ParticleSystem effect)
    {
        // パーティクルが再生中なら待つ
        while (effect != null && effect.IsAlive(true))
        {
            yield return null;
        }

        // シーン切り替え
        SceneManager.LoadScene(nextSceneName);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            Debug.Log("障害物に衝突しました！");
            DestroyWithEffect();
        }
    }
}