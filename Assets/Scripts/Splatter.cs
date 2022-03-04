using UnityEngine;

public class Splatter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag($"Paint Target"))
        {
            ContactPoint contact = collision.GetContact(0);
            collision.gameObject.GetComponent<PaintReceiver>()
                .ReceivePaint(contact.point, contact.normal);
            Destroy(gameObject);
        }
    }
}
