using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; // 플레이어 카메라를 에디터에서 직접 할당

    private void Start()
    {
        // 플레이어 카메라가 설정되어 있는지 확인
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned in the Inspector");
        }
    }

    private void Update()
    {
        if (playerCamera != null)
        {
            // 캔버스가 플레이어 카메라를 항상 바라보도록 설정 (rotation만 조정)
            Vector3 direction = (playerCamera.position - transform.position).normalized;
            direction.y = 0; // Y축 회전을 제거하여 수평 회전만 유지
            if (direction.sqrMagnitude > 0.001f) // 방향 벡터의 크기가 0이 아닌 경우에만 회전
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = lookRotation;
                transform.Rotate(0, 180, 0); // Z축 회전 반전
            }
        }
    }
}