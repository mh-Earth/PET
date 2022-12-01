using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private GameObject destroyParticle;

    [SerializeField]
    private float PerRockSpawnDelay = 2f;
    public static float SpawnDelay;

    [Header("Camera shaking")]
    public AnimationCurve curve;
    public float duration = .3f;

    private void OnEnable()
    {
        MouseController.isRockClicked += rockDestroyed;
        PowerUps.doAimDash += rockDestroyed;
        Rocks.isGameOver += GameOver;
    }

    private void OnDisable()
    {
        MouseController.isRockClicked -= rockDestroyed;
        PowerUps.doAimDash -= rockDestroyed;
        Rocks.isGameOver += GameOver;
    }

    private void Awake()
    {
        SpawnDelay = PerRockSpawnDelay;
    }


    private void Start()
    {
        // Setting Per rock spawn time

    }


    public void rockDestroyed(GameObject rock)
    {

        GameObject destroyParticleClone = Instantiate(destroyParticle, rock.transform.position, Quaternion.identity);
        Destroy(rock);
        ScoreManger.Score++;
        StartCoroutine(shaking(duration,curve));
        Destroy(destroyParticleClone, 2f);
        return;

    }


    public IEnumerator shaking(float duration, AnimationCurve shakingCurve)
    {
        Vector3 startPosition = Camera.main.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Camera.main.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        Camera.main.transform.position = startPosition;
    }

    void GameOver(){
        
        GameObject[] rocks = GameObject.FindGameObjectsWithTag(TagManager.Rock_tag);

        foreach (var rock in rocks)
        {
            Destroy(rock);
        }

        ScoreManger.Score = 0;
        Spwaner.SpawnDelay = PerRockSpawnDelay;


    }

}
