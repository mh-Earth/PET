using UnityEngine;
using TMPro;
public class ScoreManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Score;
    [SerializeField]
    private TextMeshProUGUI ScoreText;

    
    private void Update() {
        
        ScoreText.text = "Score:" + Score.ToString();


    }




}
