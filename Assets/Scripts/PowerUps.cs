using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    [Header("Power Up values")]
    public static bool PowerUpsEnable = true;
    [SerializeField]
    private float dashSpeed = 4;
    private bool isDashing = false;
    [SerializeField]
    private float AimDashCoolDown = 20f;
    [SerializeField]
    private float AimDashCoolDownInStart = 60f;
    public static float AimDashCoolDownCounter = 0f;
    [SerializeField]
    private GameObject spawner;

    [SerializeField]
    private GameObject Aim;
    [SerializeField]
    private Sprite DashingAimSprite;
    [SerializeField]
    private Sprite DashingEndAimSprite;
    private SpriteRenderer AimSpriteRenderer;


    // Delegate for game manager to destroy rocks;
    public delegate void DoAimDash(GameObject rock);
    public static DoAimDash doAimDash;
    [SerializeField]
    private List<GameObject> activeRocks = new List<GameObject>();
    private List<GameObject> inDashingRocks = new List<GameObject>();


    private void OnEnable()
    {

        UIManager.GameRestart += reset;
    }

    private void OnDisable()
    {
        UIManager.GameRestart += reset;
    }

    private void Start()
    {

        AimSpriteRenderer = Aim.GetComponent<SpriteRenderer>();
        AimDashCoolDownCounter = Time.time + AimDashCoolDownInStart;


    }

    private void Update()
    {

        if (PowerUpsEnable)
        {


            if ((Input.GetKey(KeyCode.Alpha1) || Input.GetMouseButtonDown(1)) && Time.time > AimDashCoolDownCounter)
            {

                AimDashCoolDownCounter = Time.time + AimDashCoolDown;
                StartCoroutine(AimDash());

            }

        }


    }



    IEnumerator AimDash()
    {
        isDashing = true;
        spawner.SetActive(false);
        MouseController.AimControlEnable = false;
        MouseController.TrailEnable = true;
        // float startSpeed = Rocks.speed;
        Vector3 startPos = Aim.transform.position;

        Rocks.speed = 0.3f;



        foreach (var rock in activeRocks)
        {

            if (rock != null)
            {


                while (rock != null && Vector3.Distance(Aim.transform.position, rock.transform.position) > 0.1f)
                {
                    AimSpriteRenderer.sprite = DashingAimSprite;
                    Aim.transform.position = Vector3.MoveTowards(Aim.transform.position, rock.transform.position, dashSpeed * Time.deltaTime);
                    yield return null;

                }

                doAimDash(rock);


            }

        }



        while (Vector3.Distance(Aim.transform.position, startPos) > 0f)
        {

            AimSpriteRenderer.sprite = DashingAimSprite;
            Aim.transform.position = Vector3.MoveTowards(Aim.transform.position, startPos, dashSpeed * Time.deltaTime);
            yield return null;
        }


        Rocks.speed = 2;
        MouseController.AimControlEnable = true;
        MouseController.TrailEnable = false;

        spawner.SetActive(true);
        isDashing = false;

        activeRocks.Clear();
        activeRocks.AddRange(inDashingRocks);
        inDashingRocks.Clear();

        yield return new WaitForSeconds(.15f);
        AimSpriteRenderer.sprite = DashingEndAimSprite;
        yield break;

    }


    void reset()
    {

        AimDashCoolDownCounter = Time.time + AimDashCoolDownInStart;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag(TagManager.Rock_tag) && !isDashing)
        {

            activeRocks.Add(other.gameObject);

        }

        if (isDashing && other.CompareTag(TagManager.Rock_tag))
        {

            inDashingRocks.Add(other.gameObject);

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Rock_tag) && !isDashing)
        {

            activeRocks.Remove(other.gameObject);

        }

    }




}
