using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{

    GameObject playerObject;

    Health health;
    PlayerManager manager;

    RangeWeapon rangeWeapon;
    MeleeWeapon meleeWeapon;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        health = playerObject.GetComponent<Health>();
        manager = playerObject.GetComponent<PlayerManager>();
    }

    public void savePlayer()
    {
        SaveSystem.saveData(new PlayerData(manager), FILENAME.PLAYER);
    }

    public void loadPlayer()
    {
        PlayerData pl = SaveSystem.loadData<PlayerData>(FILENAME.PLAYER);
        Debug.Log(pl.x + " " + pl.y);

        playerObject.transform.position = new Vector3(pl.x, pl.y);
        health.setHealth(pl.health);

        manager.setHealthText(pl.health);
    }
}
