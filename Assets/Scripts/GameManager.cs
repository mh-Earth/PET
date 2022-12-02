using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private GameObject destroyParticle;
    [SerializeField]
    private GameObject GameOverWindow;
    [SerializeField]
    private TextMeshProUGUI GameOverWindowScoreText;

    [SerializeField]
    private float PerRockSpawnDelay = 2f;
    public static float SpawnDelay;

    [Header("Camera shaking")]
    public AnimationCurve curve;
    public float duration = .3f;

    public delegate void GameUpdate();
    public static GameUpdate GameRestart;

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
        
        if(destroyParticleClone != null){
            Destroy(destroyParticleClone, 2f);
        }

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

        PowerUps.PowerUpsEnable = false; 
        GameOverWindow.SetActive(true);
        GameOverWindowScoreText.text = ScoreManger.Score.ToString();
        Time.timeScale = 0;


    }

}
