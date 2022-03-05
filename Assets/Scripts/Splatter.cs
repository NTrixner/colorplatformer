using UnityEngine;

public class Splatter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PaintReceiver pr = collision.gameObject.GetComponent<PaintReceiver>();
        if (pr != null)
        {
            ContactPoint contact = collision.GetContact(0);
            pr.ReceivePaint(contact.point, contact.normal);
            Destroy(gameObject);
        }
    }
}
