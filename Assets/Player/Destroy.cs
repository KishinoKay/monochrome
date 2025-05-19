using UnityEngine;

public class Destroy : MonoBehaviour
{
    public ParticleSystem destroyEffect;
    public void DestroyWithEffect()
    {
        var effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        effect.Play();
        //Destroy(gameObject);
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
