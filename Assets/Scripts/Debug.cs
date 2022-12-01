using UnityEngine;
using TMPro;

public class Debug : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SpawnDelay;
    [SerializeField]
    private TextMeshProUGUI RockInfo;
    [SerializeField]
    private TextMeshProUGUI AimDashCoolDown;

    private void OnEnable()
    {
        MouseController.isRockClicked += rockDestroyed;
    }

    private void OnDisable()
    {
        MouseController.isRockClicked -= rockDestroyed;
    }


    void rockDestroyed(GameObject rock){

        RockInfo.text = rock.name.ToString();

    }

    private void LateUpdate() {
        
        AimDashCoolDown.text = (PowerUps.AimDashCoolDownCounter - Time.time).ToString();
        SpawnDelay.text = "SpawnDelay:" + Spwaner.SpawnDelay.ToString() +"s";

    }
    

}
