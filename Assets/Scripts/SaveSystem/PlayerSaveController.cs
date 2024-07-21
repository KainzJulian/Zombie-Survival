using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{
    GameObject playerObject;

    public void savePlayer()
    {
        // PlayerManager manager = PlayerManager.instance;
        // playerObject = PlayerManager.instance.gameObject;

        // Weapon weapon = playerObject.GetComponent<WeaponController>().weapon;

        // if (weapon is RangeWeapon rangeWeapon)
        //     SaveSystem.saveData(new RangeWeaponData(rangeWeapon), FILENAME.WEAPON);
        // if (weapon is MeleeWeapon meleeWeapon)
        //     SaveSystem.saveData(new MeleeWeaponData(meleeWeapon), FILENAME.WEAPON);

        // SaveSystem.saveData(new PlayerData(manager), FILENAME.PLAYER);
    }

    public void loadPlayer()
    {
        // playerObject = PlayerManager.instance.gameObject;

        // PlayerData pl = SaveSystem.loadData<PlayerData>(FILENAME.PLAYER);
        // Debug.Log(pl.x + " " + pl.y);

        // WeaponData weapon = SaveSystem.loadData<WeaponData>(FILENAME.WEAPON);

        // if (weapon is RangeWeaponData rangeData)
        // playerObject.GetComponent<RangeWeapon>().setData(rangeData);

        // if (weapon is MeleeWeaponData meleeData)
        //     playerObject.GetComponent<RangeWeapon>().setData(meleeData);

        // playerObject.transform.position = new Vector3(pl.x, pl.y);
        // playerObject.GetComponent<Health>().setHealth(pl.health);

        // PlayerManager.instance.setHealthText(pl.health);
    }
}
