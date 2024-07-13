using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{

    GameObject playerObject;

    RangeWeapon rangeWeapon;
    MeleeWeapon meleeWeapon;

    Weapon weapon;

    public void savePlayer()
    {
        PlayerManager manager = PlayerManager.instance;
        playerObject = PlayerManager.instance.gameObject;

        weapon = playerObject.GetComponent<WeaponController>().weapon;

        if (weapon is RangeWeapon rangeWeapon)
            SaveSystem.saveData(rangeWeapon, FILENAME.WEAPON);
        if (weapon is MeleeWeapon meleeWeapon)
            SaveSystem.saveData(meleeWeapon, FILENAME.WEAPON);


        SaveSystem.saveData(new PlayerData(manager), FILENAME.PLAYER);
    }

    public void loadPlayer()
    {
        playerObject = PlayerManager.instance.gameObject;

        PlayerData pl = SaveSystem.loadData<PlayerData>(FILENAME.PLAYER);
        Debug.Log(pl.x + " " + pl.y);

        weapon = SaveSystem.loadData<Weapon>(FILENAME.WEAPON);

        playerObject.GetComponent<WeaponController>().weapon = weapon;

        playerObject.transform.position = new Vector3(pl.x, pl.y);
        playerObject.GetComponent<Health>().setHealth(pl.health);

        PlayerManager.instance.setHealthText(pl.health);
    }
}
