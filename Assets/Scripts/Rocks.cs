using UnityEngine;

public class Rocks : MonoBehaviour
{


    public static float speed = 2;
    // public static float ;

    private Vector3 EggPos;


    public delegate void GameOver();
    public static GameOver isGameOver;

    private void Start()
    {
        EggPos = GameObject.FindGameObjectWithTag(TagManager.Egg_Tag).transform.position;
        // speed = Random.Range(speed,speed+.5f);

    }

    // Moving the rock towed egg
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, EggPos, speed * Time.deltaTime);
    }


    // Destroy this is the rock touches the Egg
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(TagManager.Egg_Tag))
        {
            Destroy(gameObject);
            isGameOver();


        }
    }


}
