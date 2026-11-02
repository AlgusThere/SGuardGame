using UnityEngine;

public class UpgradeGun : MonoBehaviour
{
    [SerializeField] int _UpgradeCost = 10;
    // [SerializeField] float _CostMultiplier = 1.5f;

    public void DoUpgrade()
    {
        EventManager.UpgradeFireRate(_UpgradeCost);
    }
}
