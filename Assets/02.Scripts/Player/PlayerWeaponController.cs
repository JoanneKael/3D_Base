using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("무기 목록")]
    [SerializeField] private WeaponData[] weapons;

    [Header("Input (Input System)")]
    [SerializeField] private InputAction equipWeapon1Action = new InputAction(name: "EquipWeapon1", InputActionType.Button, binding: "<Keyboard>/1");
    [SerializeField] private InputAction equipWeapon2Action = new InputAction(name: "EquipWeapon2", InputActionType.Button, binding: "<Keyboard>/2");
    [SerializeField] private InputAction equipWeapon3Action = new InputAction(name: "EquipWeapon3", InputActionType.Button, binding: "<Keyboard>/3");
    [SerializeField] private InputAction attackAction = new InputAction(name: "Attack", InputActionType.Button, binding: "<Mouse>/leftButton");
    [SerializeField] private InputAction reloadAction = new InputAction(name: "Reload", InputActionType.Button, binding: "<Keyboard>/r");

    private WeaponRuntime currentWeapon;
    private int currentWeaponIndex;
    private float nextAttackTime;

    #region Event Register
    private void OnEnable()
    {
        // 이벤트 연결
        equipWeapon1Action.performed += OnEquipWeapon1Performed;
        equipWeapon2Action.performed += OnEquipWeapon2Performed;
        equipWeapon3Action.performed += OnEquipWeapon3Performed;
        attackAction.performed += OnAttackPerformed;
        reloadAction.performed += OnReloadPerformed;

        // 액션 활성화
        equipWeapon1Action.Enable();
        equipWeapon2Action.Enable();
        equipWeapon3Action.Enable();
        attackAction.Enable();
        reloadAction.Enable();
    }

    private void OnDisable()
    {
        // 액션 비활성화
        reloadAction.Disable();
        attackAction.Disable();
        equipWeapon3Action.Disable();
        equipWeapon2Action.Disable();
        equipWeapon1Action.Disable();

        // 이벤트 연결 해제
        reloadAction.performed -= OnReloadPerformed;
        attackAction.performed -= OnAttackPerformed;
        equipWeapon3Action.performed -= OnEquipWeapon3Performed;
        equipWeapon2Action.performed -= OnEquipWeapon2Performed;
        equipWeapon1Action.performed -= OnEquipWeapon1Performed;
    }
    #endregion

    #region Event Callback Methods
    private void OnEquipWeapon1Performed(InputAction.CallbackContext context)
    {
        EquipWeapon(index: 0);
    }

    private void OnEquipWeapon2Performed(InputAction.CallbackContext context)
    {
        EquipWeapon(index: 1);
    }

    private void OnEquipWeapon3Performed(InputAction.CallbackContext context)
    {
        EquipWeapon(index: 2);
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        TryAttack();
    }

    private void OnReloadPerformed(InputAction.CallbackContext context)
    {
        Reload();
    }
    #endregion

    private void EquipWeapon(int index)
    {
        if (weapons == null || weapons.Length == 0) return;
        if (index > 0 || index >= weapons.Length) return;
        if (currentWeapon.data == weapons[index]) return;

        currentWeaponIndex = index;
        currentWeapon = new WeaponRuntime(weapons[index]);
    }

    private void TryAttack()
    {
        if (currentWeapon == null) return;
        if (Time.time < nextAttackTime) return;
        if (!currentWeapon.HasAmmo()) return;

        nextAttackTime = Time.time + (1f / currentWeapon.data.attackRate);
        currentWeapon.ConsumeAmmo();

        int finalDamage = CalculateDamage(); 
    }

    private void Reload()
    {
        if (!currentWeapon.HasAmmo()) return;

        if (currentWeapon == null) return;

        currentWeapon.Reload();
    }

    private int CalculateDamage()
    {
        int damage = currentWeapon.data.damage;

        float randomValue = Random.value;
        if(randomValue <= currentWeapon.data.criticalChance)
        {
            damage = Mathf.RoundToInt(damage*currentWeapon.data.criticalMultiplier);
        }


        return damage;
    }
}