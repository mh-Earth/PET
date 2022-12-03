using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PowerUps : MonoBehaviour
{

    [Header("Power Up values")]
    public static bool PowerUpsEnable = true;
    [SerializeField]
    private GameObject spawner;
    [Header("Aim")]
    [SerializeField]
    private GameObject Aim;
    [SerializeField]
    private Sprite DashingAimSprite;
    [SerializeField]
    private Sprite DashingEndAimSprite;
    private SpriteRenderer AimSpriteRenderer;
    private bool isDashing = false;

    [Header("AimDash")]
    [SerializeField]
    private float dashSpeed = 4;
    [SerializeField]
    private float AimDashCoolDown = 20f;
    [SerializeField]
    private float AimDashCoolDownInStart = 60f;
    public static float AimDashCoolDownCounter = 0f;

    [Header("Ghost Fire")]
    [SerializeField]
    private GameObject AimClone;
    [SerializeField]
    private float GhostDashSpeed = 200;
    [SerializeField]
    private float GhostFireCoolDown = 90f;
    [SerializeField]
    private float GhostFireCoolDownInStart = 90f;
    public static float GhostFireCoolDownCounter = 0f;

    // Delegate for game manager to destroy rocks;
    public delegate void DoAimDash(GameObject rock);
    public static DoAimDash doAimDash;
    [SerializeField]
    private List<GameObject> activeRocks = new List<GameObject>();
    private List<GameObject> inDashingRocks = new List<GameObject>();



    private void Awake()
    {

        Controls PowerUps = new Controls();
        PowerUps.Enable();
        // Key binding for power-ups
        PowerUps.PowerUps.AImDash.performed += _DoAimDash;
        PowerUps.PowerUps.GhostFire.performed += DoGhostFire;

    }


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
        GhostFireCoolDownCounter = Time.time + GhostFireCoolDownInStart;


    }


    void _DoAimDash(InputAction.CallbackContext cxt)
    {



        if (PowerUpsEnable && Time.time > AimDashCoolDownCounter)
        {

            AimDashCoolDownCounter = Time.time + AimDashCoolDown;
            StartCoroutine(AimDash());

        }


    }

    void DoGhostFire(InputAction.CallbackContext cxt)
    {



        if (PowerUpsEnable && Time.time > GhostFireCoolDownCounter)
        {

            GhostFireCoolDownCounter = Time.time + GhostFireCoolDown;
            StartCoroutine(GhostFire());
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



    IEnumerator GhostFire()
    {
        isDashing = true;
        spawner.SetActive(false);
        MouseController.AimControlEnable = false;
        MouseController.TrailEnable = true;

        // Vector3 startPos = Aim.transform.position;
        Vector2 center = new Vector2(.5f, .5f);
        Rocks.speed = 0.0f;

        GameObject[] activeRocks = GameObject.FindGameObjectsWithTag(TagManager.Rock_tag);
        AimSpriteRenderer.sprite = null;

        foreach (var rock in activeRocks)
        {

            GameObject GhostAim = Instantiate(AimClone, Aim.transform.position, Quaternion.identity);

            if (rock != null)
            {


                while (rock != null && Vector3.Distance(GhostAim.transform.position, rock.transform.position) > 0.0f)
                {
                    GhostAim.GetComponent<SpriteRenderer>().sprite = DashingAimSprite;
                    GhostAim.transform.position = Vector3.MoveTowards(GhostAim.transform.position, rock.transform.position, GhostDashSpeed * Time.deltaTime);
                    yield return null;

                }

            }

        }

        yield return new WaitForSeconds(.2f);
        foreach (var rock in activeRocks)
        {
            doAimDash(rock);

        }

        foreach (var Clone in GameObject.FindGameObjectsWithTag("AimClone"))
        {

            Destroy(Clone);

        }


        Rocks.speed = 2;
        MouseController.AimControlEnable = true;
        MouseController.TrailEnable = false;

        MouseController.TrailEnable = false;

        spawner.SetActive(true);
        isDashing = false;

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
