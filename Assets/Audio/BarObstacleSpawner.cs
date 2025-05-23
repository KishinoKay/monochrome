using UnityEngine;

public class BarObstacleSpawner : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject barPrefab;
    public float spawnInterval = 0.2f;
    public float scrollSpeed = 5f;
    public float spawnX = 13f;
    public float spawnY = 0f;
    public float baseHeight = 1f;
    public float heightMultiplier = 30f;
    public float maxHeight = 10f; // ★ 追加：高さの上限
    public int spectrumIndex = 2;

    private float timer = 0f;
    private float[] spectrum = new float[64];

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
            float energy = spectrum[spectrumIndex];
            SpawnBarObstacle(energy);
            timer = 0f;
        }
    }

    void SpawnBarObstacle(float energy)
    {
        float height = baseHeight + energy * heightMultiplier;

        // ★ 高さの制限を追加
        height = Mathf.Min(height, maxHeight);

        Vector3 spawnPos = new Vector3(spawnX, spawnY + height / 2f, 0);

        GameObject bar = Instantiate(barPrefab, spawnPos, Quaternion.identity);
        bar.transform.localScale = new Vector3(0.5f, height, 1f);
        bar.AddComponent<ObstacleMover>().speed = scrollSpeed;
    }
}