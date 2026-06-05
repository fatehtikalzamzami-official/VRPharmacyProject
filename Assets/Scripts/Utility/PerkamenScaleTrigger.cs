using UnityEngine;

public class PerkamenScaleTrigger : MonoBehaviour
{
    [SerializeField] private Transform perkamenSnapPoint;

    private bool hasPlacedPerkamen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlacedPerkamen)
            return;

        if (!other.CompareTag("Perkamen"))
            return;

        hasPlacedPerkamen = true;

        other.transform.position = perkamenSnapPoint.position;
        other.transform.rotation = perkamenSnapPoint.rotation;

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        Debug.Log("Kertas perkamen berhasil diletakkan di piring neraca.");
    }
}