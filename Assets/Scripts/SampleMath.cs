using UnityEngine;

public class SampleMath : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target != null)
        {
            float dx = target.position.x - transform.position.x;
            float dy = target.position.y - transform.position.y;

            // Manual calculation using Pythagorean theorem
            float distance = Mathf.Sqrt(Mathf.Pow(dx, 2) + Mathf.Pow(dy, 2));

            // Built-in Vector3.Distance
            float vectorDist = Vector3.Distance(target.position, transform.position);

            Debug.Log($"Distance: {distance:F2}, Vector: {vectorDist:F2}");
        }
    }
}
