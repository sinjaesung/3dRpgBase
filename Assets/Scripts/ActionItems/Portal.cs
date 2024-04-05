using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }
    [SerializeField]
    private Portal[] linkedPortals;
    private PortalController PortalController { get; set; }
    private void Start()
    {
        PortalController = FindObjectOfType<PortalController>();
        TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
        PortalController.ActivatePortal(linkedPortals);
        // base.Interact(); 이걸 호출안하면 조상들의 interact 실행되지 않는다.
        playerAgent.ResetPath();
    }
}
