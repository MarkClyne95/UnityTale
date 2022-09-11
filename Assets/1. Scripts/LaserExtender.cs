using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class LaserExtender : MonoBehaviour
{
   [SerializeField]private float defDistanceRay = 100;
   public Transform laserFirePoint;
   public LineRenderer m_lineRenderer;
   private Transform m_Transform;

   private void Awake()
   {
      m_Transform = GetComponent<Transform>();
   }

   public void ShootLaser()
   {
      if (Physics2D.Raycast(m_Transform.position, transform.right))
      {
         RaycastHit2D _hit = Physics2D.Raycast(m_Transform.position, transform.right);
         Draw2DRay(laserFirePoint.position, _hit.point);
      }
      else
      {
         Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
      }
   }

   private void Draw2DRay(Vector2 startPos, Vector2 endPos)
   {
      m_lineRenderer.SetPosition(0, startPos);
      m_lineRenderer.SetPosition(0, endPos);
   }
}
