using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{

    GameObject playerObject;

    RangeWeapon rangeWeapon;
    MeleeWeapon meleeWeapon;

    public void savePlayer()
    {
        SaveSystem.saveData(new PlayerData(PlayerManager.instance), FILENAME.PLAYER);
    }

    public void loadPlayer()
    {
        playerObject = PlayerManager.instance.gameObject;

        PlayerData pl = SaveSystem.loadData<PlayerData>(FILENAME.PLAYER);
        Debug.Log(pl.x + " " + pl.y);

        playerObject.transform.position = new Vector3(pl.x, pl.y);
        playerObject.GetComponent<Health>().setHealth(pl.health);

        PlayerManager.instance.setHealthText(pl.health);
    }
}
