﻿using System.Linq;
using UnityEngine;

public class PilotsManager : MonoBehaviour, IDataModelManager
{   
    public static PilotsManager Instance;

    public PilotsContainer pilotsContainer;
    public Pilot[] Pilots { get => pilotsContainer.pilots; }

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

    public void Init()
    {
        if (DataModelsUtils.SaveDataExists(Pilot.FOLDER_NAME))
        {
            LoadDataAsync();
        }
    }

    public void AwardXp(Ship ship, int xp)
    {
        if (ship != null && ship.Pilot != null)
        {
            ship.Pilot.Xp += xp;
        }
    }

    public void HirePilot(int index)
    {
        Instance.Pilots[index].IsHired = true;
    }

    public Pilot[] GetHiredPilots()
    {
        return Instance.Pilots.Where(p => p.IsHired) as Pilot[];
        
    }

    public Pilot[] GetPilotsForHire()
    {
        return Instance.Pilots.Where(p => !p.IsHired) as Pilot[];
    }

    public void SaveData()
    {
        foreach (Pilot pilot in Instance.Pilots)
        {
            pilot.SaveData();
        }
    }

    public async void LoadDataAsync()
    {
        foreach (Pilot pilot in Instance.Pilots)
        {
            await pilot.LoadDataAsync();
        }
    }

    public void DeleteData()
    {
        Instance.DeleteData();
    }
}