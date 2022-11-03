using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierWeapon : MonoBehaviour
{
    public int damage;
    public CircleCollider2D coll;
    public ParticleSystem particle;
    public int level;

    private void Start()
    {
        level = 1;
    }


    public void UpdateDamage()
    {

    }

    public void UpdateRadius()
    {
        if (level == 1)
        {
            particle.gameObject.SetActive(true);
        }
        else
        {
            particle.startSize += 1;
            coll.radius += 0.4f;
        }

        level++;
    }


    //level 1 : 0.85 Radius , 2 Particle size
    // Level 2 : 1.25 Radius , 3 Particle size
    // Level 3 : 1.65 Radius , 4 Particle size
    // Radius += 0.40 , size + = 1


}
