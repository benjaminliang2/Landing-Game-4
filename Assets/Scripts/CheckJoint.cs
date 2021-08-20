using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJoint : MonoBehaviour
{
    public bool jointBroke = false;
    // Start is called before the first frame update
    private void OnJointBreak2D(Joint2D joint)
    {
        jointBroke = true;
    }
}
