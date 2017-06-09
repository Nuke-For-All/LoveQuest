using System.Collections;
using UnityEngine;

public class PortalElectricity : PortalEntity {

    PortalBehaviours pb;
	
    PortalElectricity()
    {
        pb = new PortalBehaviours();
    }

	void FixedUpdate () {
        pb.RotationMove(rb, rotationSpeed);
	}

  
}
