using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _segments;

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        _line.enabled = true;

        float interpolant = Vector3.Distance(a, b) / length;

        float offest = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 aDown = a + Vector3.down * offest;
        Vector3 bDown = b + Vector3.down * offest;

        _line.positionCount = _segments + 1;

        for (int i = 0; i < _segments + 1; i++)
        {
            _line.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i / _segments));
        }
    }

    public void Hide()
    {
        _line.enabled = false;
    }
}
