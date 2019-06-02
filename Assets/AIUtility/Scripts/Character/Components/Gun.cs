using UnityEngine;

public class Gun : MonoBehaviour
{
    public int MaxBullet = 15;
    public int CurrentBullet = 15;

    public void Fire()
    {
        CurrentBullet--;

        if (CurrentBullet <= 0)
            CurrentBullet = 0;
    }

    public void Reload()
    {
        CurrentBullet = MaxBullet;
    }
}