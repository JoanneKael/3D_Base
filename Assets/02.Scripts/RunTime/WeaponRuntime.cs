using UnityEngine;

public class WeaponRuntime : MonoBehaviour
{
    public WeaponData data;
    public int currentAmmo;

    // 생성자
    public WeaponRuntime(WeaponData data)
    {
        this.data = data;

        if (data.useAmmo)
            currentAmmo = data.magazineSize;
        else
            currentAmmo = 0;
    }

    // 탄약 확인 및 소모
    public bool HasAmmo()
    {
        if (!data.useAmmo)
            return true;

        return currentAmmo > 0;
    }

    public void ConsumeAmmo()
    {
        if (!data.useAmmo)
            return;

        currentAmmo--;
    }

    // 재장전
    public void Reload()
    {
        if (!data.useAmmo)
            return;

        currentAmmo = data.magazineSize;
    }
}
