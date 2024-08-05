using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Shoot();
}
/*

public class Pistol : Weapon
{
    public override void Shoot()
    {
        Debug.Log("Pistol Shoot!");
        // Логика стрельбы из пистолета
    }
}

public class Rifle : Weapon
{
    public override void Shoot()
    {
        Debug.Log("Rifle Shoot!");
        // Логика стрельбы из автомата
    }
}

public class Shotgun : Weapon
{
    public override void Shoot()
    {
        Debug.Log("Shotgun Shoot!");
        // Логика стрельбы из дробовика
    }
}

public class GrenadeLauncher : Weapon
{
    public override void Shoot()
    {
        Debug.Log("Grenade Launcher Shoot!");
        // Логика стрельбы из гранатомёта
    }
}
*/
