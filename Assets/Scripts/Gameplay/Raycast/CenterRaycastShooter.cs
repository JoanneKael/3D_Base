using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CenterRaycastShooter : MonoBehaviour
{
    [SerializeField] private Camera m_cam;               // Ray 기준
    [SerializeField] private LayerMask m_hittableMask;   // Ray 필터링
    [SerializeField] private float m_maxDistance = 100f; // Ray 최대 거리

    private PlayerInput _playerInput;
    private InputAction _fireAction;

    private void Awake()
    {
        _playerInput  = GetComponent<PlayerInput>();
        _fireAction = _playerInput.actions.FindAction("Fire", true);
        if (m_cam == null) m_cam = Camera.main;
    }

    private void OnRayFire(InputAction.CallbackContext _)
    {
        //if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        Vector2 screenCenter = new(Screen.width * 0.5f, Screen.height * 0.5f);
        Ray _ray = m_cam.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(_ray, out var hit, m_maxDistance, m_hittableMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(_ray.origin, hit.point, Color.green, 1.0f);
        }
        else
        {
            Debug.DrawLine(_ray.origin, _ray.direction * m_maxDistance, Color.yellow, 0.5f);
        }
    }

    private void OnEnable()
    {
        _fireAction.performed += OnRayFire;
    }

    private void OnDisable()
    {
        _fireAction.performed -= OnRayFire;
    }


}
