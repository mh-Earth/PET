using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private float canClickDelay;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        spriteRenderer.sprite = Aim_Green;
    }

    void FollowMouse()
    {



        Vector3 mouse = Input.mousePosition;
        mouse.z = 10;

        transform.position = Camera.main.ScreenToWorldPoint(mouse);

    }

    void AimTrail(){

        GameObject a = Instantiate(trail, transform.position, Quaternion.identity);
        Destroy(a, .2f);

    }



    private void Update()
    {

        if (AimControlEnable)
        {

            FollowMouse();
        }

        if (TrailEnable)
        {
            
            AimTrail();

        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag(TagManager.Rock_tag))
        {

            spriteRenderer.sprite = Aim_Red;

            if (Input.GetMouseButtonDown(0))
            {

                // transform.position = other.transform.position;
                isRockClicked(other.gameObject);
                return;


            }

        }
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


        }

    }



}
