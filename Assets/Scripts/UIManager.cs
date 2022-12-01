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

    public void Exit()
    {

        Application.Quit();


    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {

            Time.timeScale = 1;
            PauseResume.GetComponent<Image>().sprite = ResumeSprite;
        }

        else
        {

            Time.timeScale = 0;
            PauseResume.GetComponent<Image>().sprite = PauseSprite;

        }

    }




}
