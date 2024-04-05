using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private Portal[] portal;
    private Player player;
    private GameObject panel;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        panel = transform.Find("Panel_Portal").gameObject;
    }

    public void ActivatePortal(Portal[] portals)
    {
        panel.SetActive(true);
        for(int i=0; i<portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<TextMeshProUGUI>().text = portals[i].name;
            int x = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(x, portals[x]); });
        }
    }

    void OnPortalButtonClick(int portalIndex, Portal portal)
    {
        Debug.Log("포탈버튼클릭 portalIndex : " + portalIndex);
        player.transform.position = portal.TeleportLocation;
        foreach(Button button in GetComponentsInChildren<Button>())
        {
            Debug.Log("포탈버튼 클릭시에 현재 있는 모든 버튼요소들 다 삭제!:" + button.name);
            Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }
}
