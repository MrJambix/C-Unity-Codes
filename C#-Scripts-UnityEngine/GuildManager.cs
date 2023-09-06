using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GuildManager : MonoBehaviour
{
    public GameObject GuildUI; // Drag your GuildUI panel here.
    public InputField inviteInputField; // Drag your input field here.
    public Transform onlineMembersContainer; // Drag your online members container inside the scroll view here.
    public Transform offlineMembersContainer; // Drag your offline members container inside the scroll view here.
    public GameObject memberPrefab; // Create a prefab for a member listing (with a Text component) and drag it here.

    private List<string> onlineMembers = new List<string>(); // Example data
    private List<string> offlineMembers = new List<string>(); // Example data

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGuildUI();
        }
    }

    public void ToggleGuildUI()
    {
        GuildUI.SetActive(!GuildUI.activeSelf);
    }

    public void InvitePlayer()
    {
        string playerName = inviteInputField.text;

        // Here, you would usually send this playerName to your server to process the guild invitation.
        // For simplicity, this example will not cover the server-side of things.
        Debug.Log($"Invited player {playerName}");
    }

    // Call this function when you fetch member data from your server.
    public void UpdateMembersList(List<string> online, List<string> offline)
    {
        onlineMembers = online;
        offlineMembers = offline;

        PopulateList(onlineMembersContainer, onlineMembers);
        PopulateList(offlineMembersContainer, offlineMembers);
    }

    private void PopulateList(Transform container, List<string> members)
    {
        // Clear previous entries
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // Add new entries
        foreach (string member in members)
        {
            GameObject newEntry = Instantiate(memberPrefab, container);
            newEntry.GetComponent<Text>().text = member;
        }
    }
}
