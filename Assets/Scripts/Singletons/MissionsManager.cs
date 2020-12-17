﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionsManager : MonoBehaviour
{
    public static MissionsManager Instance { get; private set; }

    public MissionContainer missionContainer;
    public List<Mission> missionsAcceptedInNoticeBoard;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Init();
    }

    void Init()
    {
        missionsAcceptedInNoticeBoard = new List<Mission>();

        foreach(Mission mission in Instance.missionContainer.missions)
        {
            if (mission.hasBeenAcceptedInNoticeBoard)
            {
                missionsAcceptedInNoticeBoard.Add(mission);
            }
        }
    }

  //  void Start()
  //  {
  //      playerMoneyText.text = "$" + PlayerManager.Instance.playerData.playerMoney;
  //      GenerateMissionButtons();
  //  }

  //  void GenerateMissionButtons()
  //  {
  //      missionsPanel.GetComponentInChildren<GridLayoutGroup>();    

  //      foreach(Mission mission in missionContainer.missions)
  //      {
  //          GameObject newButton = Instantiate(missionButtonPrefab);
  //          MissionButton missionButton = newButton.GetComponent<MissionButton>();

  //          missionButton.Setup(mission);

  //          newButton.transform.parent = missionsPanel.transform;

  //          missionButton.button.onClick.AddListener( delegate { PerformMission(missionButton); } );
  //      }
  //  }

  //  void PerformMission(MissionButton missionButton)
  //  {
  //      if (missionButton.mission.inProgress)
  //      {
  //          return;
  //      }
  //      missionButton.slider.value = 0f; 
  //      StartCoroutine(WaitForMission(missionButton));
  //  }

  //  IEnumerator WaitForMission(MissionButton missionButton)
  //  {
  //      Mission mission = missionButton.mission;
  //      mission.inProgress = true;

  //      // Scale timer by a factor of n 
  //      // to match the progress intervals 
		//int scaledTimer = mission.missionDurationInSeconds * MissionConstants.sliderScaleFactor;
  //      int currentTimer = scaledTimer;
		//float waitTime = 1f / MissionConstants.sliderScaleFactor;
  //      while(currentTimer > 0)
  //      {
  //          // Wait for a fraction of a second 
  //          // in order to accomodate missions 
  //          // under a second in length 
  //          yield return new WaitForSeconds(waitTime);
  //          currentTimer--;
		//	missionButton.slider.value += 1f / scaledTimer; 
  //          missionButton.SetMissionTime(timeLeftInSeconds: currentTimer / MissionConstants.sliderScaleFactor);
  //      }

  //      mission.ProcessOutcomes();
  //      missionButton.ResetMissionTime();
  //      playerMoneyText.text = "$" + PlayerManager.Instance.playerData.playerMoney;
  //      mission.inProgress = false; 
  //  }

  //  void Update()
  //  {
        
  //  }
}
