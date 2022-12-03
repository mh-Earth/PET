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
    [SerializeField]
    private TextMeshProUGUI GhostFireCoolDown;

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
        
        AimDashCoolDown.text = ((int)PowerUps.AimDashCoolDownCounter - (int)Time.time).ToString() + "s";
        GhostFireCoolDown.text = ((int)PowerUps.GhostFireCoolDownCounter - (int)Time.time).ToString() + "s";
        SpawnDelay.text = "SpawnDelay:" + Spwaner.SpawnDelay.ToString() +"s";

    }
    

}
