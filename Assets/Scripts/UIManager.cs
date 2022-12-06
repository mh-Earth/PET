using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Animator MainMenuAnimator;

    [Header("Button sprites")]
    [SerializeField]
    private Button PauseResume;
    [SerializeField]
    private Sprite ResumeSprite;
    [SerializeField]
    private Sprite PauseSprite;
    [SerializeField]
    private GameObject PauseWindow;


    public delegate void GameUpdate();
    public static GameUpdate GameRestart;

    private void Awake()
    {

        Controls UIControl = new Controls();
        UIControl.UI.Enable();
        UIControl.UI.PauseResume.performed += _ => Pause();



    }

    IEnumerator loadPlay()
    {

        MainMenuAnimator.SetBool("Play", true);
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("GamePlay");


    }

    public void Play()
    {

        StartCoroutine(loadPlay());

    }

    public void MeinMenu()
    {

        SceneManager.LoadScene(0);

    }

    public void Exit()
    {

        Application.Quit();


    }

    public void Pause()
    {
        
        if (GameManager.GameStatus == TagManager.GameRunningStatus || GameManager.GameStatus == TagManager.PauseStatus)
        {

            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseResume.GetComponent<Image>().sprite = ResumeSprite;
                PauseWindow.SetActive(false);
                GameManager.GameStatus = TagManager.GameRunningStatus;
            }

            else
            {

                GameManager.GameStatus = TagManager.PauseStatus;
                PauseWindow.SetActive(true);
                Time.timeScale = 0;
                PauseResume.GetComponent<Image>().sprite = PauseSprite;

            }

        }
    }

    public void restart()
    {
        GameRestart();
        if(GameManager.GameStatus == TagManager.GameOverStatus){
            GameObject.FindGameObjectWithTag("Gameoverwindow").SetActive(false);
        }
        else{
            PauseWindow.SetActive(false);
        }

        Time.timeScale = 1;
        PowerUps.PowerUpsEnable = true;


        GameObject[] rocks = GameObject.FindGameObjectsWithTag(TagManager.Rock_tag);

        foreach (var rock in rocks)
        {
            Destroy(rock);
        }
        GameObject[] RockDestroy = GameObject.FindGameObjectsWithTag("RockDestory");

        foreach (var RockDestroys in RockDestroy)
        {
            Destroy(RockDestroys);
        }

        ScoreManger.Score = 0;
        Spwaner.SpawnDelay = GameManager.SpawnDelay;
        GameManager.GameStatus = TagManager.GameRunningStatus;


    }




}
