using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Vector2[] bounds;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ground"))
        {
            ContactPoint[] contactPoints = collision.contacts;
            if (contactPoints.Length >= 4) // Make sure we have at least 4 points for a rectangle
            {
                // Calculate the bounds of the rectangle
                float minX = Mathf.Infinity;
                float maxX = -Mathf.Infinity;
                float minZ = Mathf.Infinity;
                float maxZ = -Mathf.Infinity;

                for (int i = 0; i < contactPoints.Length; i++)
                {
                    Vector3 point = contactPoints[i].point;
                    if (point.x < minX)
                        minX = point.x;
                    if (point.x > maxX)
                        maxX = point.x;
                    if (point.z < minZ)
                        minZ = point.z;
                    if (point.z > maxZ)
                        maxZ = point.z;
                }

                // Calculate the corners of the rectangle
                Vector2 topLeft = new Vector2(minX, maxZ);
                Vector2 topRight = new Vector2(maxX, maxZ);
                Vector2 bottomLeft = new Vector2(minX, minZ);
                Vector2 bottomRight = new Vector2(maxX, minZ);

                bounds = new Vector2[4];

                bounds[0] = topLeft;
                bounds[1] = topRight;
                bounds[2] = bottomRight;
                bounds[3] = bottomLeft;
                

                // Print the corners of the rectangle
                //Debug.Log("Top left: " + topLeft);
                //Debug.Log("Top right: " + topRight);
                //Debug.Log("Bottom left: " + bottomLeft);
                //Debug.Log("Bottom right: " + bottomRight);

                // Draw a debug wireframe of the rectangle
                //Debug.DrawLine(topLeft, topRight, Color.green);
                //Debug.DrawLine(topRight, bottomRight, Color.green);
                //Debug.DrawLine(bottomRight, bottomLeft, Color.green);
                //Debug.DrawLine(bottomLeft, topLeft, Color.green);
            }
        }
    }


}
