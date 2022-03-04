using UnityEngine;

public class PaintReceiver : MonoBehaviour
{
    public void ReceivePaint(Vector3 point, Vector3 normal)
    {
        Debug.Log(name + " received paint at " + point + " with normals " + normal);
    }
}
