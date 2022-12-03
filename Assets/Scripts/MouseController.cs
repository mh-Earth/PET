using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{


    [Header("Aims")]
    [SerializeField]
    private Sprite Aim_Red;
    [SerializeField]
    private Sprite Aim_Green;
    [SerializeField]
    public static bool TrailEnable = false;
    [SerializeField]
    private GameObject trail;
    private SpriteRenderer spriteRenderer;
    public static bool AimControlEnable = true;

    // Delegates
    public delegate void rockClicked(GameObject rock);
    public static rockClicked isRockClicked;
    [SerializeField]
    private List<GameObject> InAimRange = new List<GameObject>();



    private void Awake()
    {


        Controls AimControl = new Controls();
        AimControl.Aim.Enable();
        AimControl.Aim.shoot.performed += _ => Shoot();
    }


    private void Shoot()
    {

        if (InAimRange.Count > 0)
        {

            isRockClicked(InAimRange[0]);

        }


    }





    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        spriteRenderer.sprite = Aim_Green;
    }

    void FollowMouse()
    {
        Vector3 Pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Pos.z = 10;
        transform.position = Pos;

    }

    void AimTrail()
    {

        GameObject a = Instantiate(trail, transform.position, Quaternion.identity);
        Destroy(a, .2f);

    }



    private void Update()
    {


        if (TrailEnable)
        {

            AimTrail();

        }

        if (AimControlEnable)
        {

            FollowMouse();
        }


    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.Rock_tag))
        {

            spriteRenderer.sprite = Aim_Red;
            InAimRange.Add(other.gameObject);

        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag(TagManager.Menu_key_tag))
        {

            spriteRenderer.sprite = Aim_Red;

        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag(TagManager.Rock_tag) || other.CompareTag(TagManager.Menu_key_tag))
        {

            spriteRenderer.sprite = Aim_Green;
            InAimRange.Remove(other.gameObject);


        }

    }



}
