using UnityEngine;
using UnityEngine.Events;

public class Teleport : MonoBehaviour
{
    [Header("Teleport Player")]
    [SerializeField] CharacterController playerCharacterController;
    [SerializeField] Transform destination;
    [SerializeField] Transform destinationParent;
    [SerializeField] UnityEvent eventAfterTeleport;

    public void TeleportPlayer()
    {
        playerCharacterController.enabled = false;
        playerCharacterController.transform.position = destination.position;
        if (destinationParent != null)
        {
            playerCharacterController.transform.SetParent(destinationParent);
        }
        else
        {
            playerCharacterController.transform.SetParent(null);
        }
        playerCharacterController.enabled = true;
        eventAfterTeleport.Invoke();
    }
}
