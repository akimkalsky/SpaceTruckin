﻿using UnityEngine;
using UnityEngine.UI;

public class MessagesUI : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject messageItemPrefab;
    public GameObject messagesListView;
    public GameObject messagesDetailView;
    public MessageDetailView messageDetailViewHandler;
    public Button backButton;

    private void Start()
    {
        backButton.AddOnClick(GoToListView);
    }

    private void OnEnable()
    {
        MessagesManager.Instance.UnlockMessages();
        GoToListView();
    }

    private void GoToListView()
    {
        messagesListView.SetActive(true);
        messagesDetailView.SetActive(false);
        CleanScrollView();
        AddMessages();
    }

    private void CleanScrollView()
    {
        foreach (Transform child in scrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void AddMessages()
    {
        foreach (Message message in MessagesManager.Instance.Messages)
        {
            if (message != null && message.IsUnlocked)
            {
                GameObject newMessage = Instantiate(messageItemPrefab, scrollViewContent.transform);
                newMessage.name = "Message";
                newMessage.GetComponent<Image>().color = GetMessageColour(message);

                MessageButtonHandler buttonHandler = newMessage.GetComponent<MessageButtonHandler>();
                buttonHandler.Init(message, () =>
                {
                    GoToDetailView(message);
                    message.IsUnread = false; 
                });
            }
        }
    }

    private void GoToDetailView(Message message)
    {
        messagesListView.SetActive(false);
        messagesDetailView.SetActive(true);
        messageDetailViewHandler.SetMessageDetails(message);

        if (message.Mission != null)
        {
            messageDetailViewHandler.SetMissionAcceptButton(message.Mission);
            messageDetailViewHandler.missionAcceptButton.gameObject.SetActive(true);
        }
        else
        {
            messageDetailViewHandler.missionAcceptButton.gameObject.SetActive(false);
        }
    }

    public void GenerateMessageItem()
    {
        GameObject newItem = new GameObject().ScaffoldUI(
            name: "MessageItem", parent: scrollViewContent, anchors: (Vector2.zero, Vector2.one));

        newItem.AddComponent<Button>();
        newItem.AddComponent<MessageButtonHandler>();
    }

    private Color GetMessageColour(Message message) => 
        message.IsUnread ? MessageConstants.UnreadColour : MessageConstants.ReadColour;
}