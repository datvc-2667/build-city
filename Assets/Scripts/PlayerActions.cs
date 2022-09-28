using UnityEngine;
using TMPro;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance))
        {
            DebugRaycast(Camera.position, hit, Camera.forward);

            Debug.Log(hit.collider.TryGetComponent<DoorController>(out DoorController doorController));
            if (hit.collider.TryGetComponent<DoorController>(out DoorController door))
            {
                Debug.Log("OnUse");
                if (door.IsOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open(transform.position);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("OpenDoor"))
        {
            OnUse();
            
        }

    }

    protected virtual void DebugRaycast(Vector3 start, RaycastHit hit, Vector3 direction)
    {

        if(hit.transform == null)
        {
            Debug.DrawRay(start, direction, Color.red);
            Debug.Log(transform.name + ": Hot Nothing");
        }
        else
        {
            Debug.DrawRay(start, direction, Color.green);
            Debug.Log(transform.name + ": Hot" + hit.transform.name);
        }
    }

}
