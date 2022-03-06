using UnityEngine;

public class Splatter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PaintReceiver pr = collision.gameObject.GetComponent<PaintReceiver>();
        if (pr != null)
        {
            FindObjectOfType<GlobalSoundProvider>().Splatter();
            ContactPoint contact = collision.GetContact(0);
            Color c = gameObject.GetComponent<Renderer>().material.color;
            pr.ReceivePaint(contact.point, contact.normal, c);
            Destroy(gameObject);
        }
    }
}
