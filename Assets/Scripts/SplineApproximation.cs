using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineApproximation : MonoBehaviour
{
    public List<Vector2> positions;
    public int countTo = 100;
    private int count = 0;

    private void OnDrawGizmos()
    {
        // Works fine in play mode.
        if (positions == null) return;
        Gizmos.color = Color.cyan;
        foreach (Vector2 pos in positions)
        {
            Gizmos.DrawSphere(pos, 0.3f);
        }

        if (positions.Count < 2) return;
        count++;
        float time = (count / (float)countTo) % 1f;
        Gizmos.color = Color.yellow;
        for (int i = 0; i < positions.Count -1; i++)
        {
            // KJ: Kinda works need more stuff more data to work better.
            //     Main thing is it has no data about entry and exit angle. 
            Vector2 posA = positions[i];
            Vector2 posB = Vector2.zero;
            Vector2 posC = positions[i + 1];
            Vector2 dist = posA - posC;
            bool isXLarger = Mathf.Abs(dist.x) < Mathf.Abs(dist.y);
            posB = new Vector2(isXLarger ? posA.x : posC.x, isXLarger ? posC.y : posA.y);
            Vector2 posAB = Vector2.Lerp(posA, posB, time);
            Vector2 posBC = Vector2.Lerp(posB, posC, time);
            Vector2 posAC_BC = Vector2.Lerp(posAB, posBC, time);
            Gizmos.DrawSphere(posAC_BC, 0.3f);
        }
    }
}
