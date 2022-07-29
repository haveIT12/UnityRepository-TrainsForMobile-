using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksSystemScript : MonoBehaviour
{
    public UserInterfaceScript uiScript;
    public List<TaskElementScript> task;
    private void Awake()
    {
        InitTasks();
    }
    public void InitTasks()
    {
        for (int i = 0; i < task.Count; i++)
        {
            task[i].Init();
        }
    }
    public bool IsAllTasksDone()
    {
        CheckDoneTasks();
        for (int i = 0; i < task.Count; i++)
        {
            if (task[i].isGeneral)
            {
                if (!task[i].isDone())
                    return false;
            }
        }
        uiScript.mainScript.GameOver("Success");
        return true;
    }
    public void CheckDoneTasks()
    {
        int t = 0;
        int o = 0;
        for (int i = 0; i < task.Count; i++)
        {
            if (task[i].isGeneral)
            {
                o++;
                if (task[i].isDone())
                    t++;
            }
        }
        uiScript.taskCompleteText.text = t + "/" + o;
    }
    public void GetInfo(TrainScript tScript, float count, string name, bool isRepair = false, bool isSell = false)
    {
        for (int i = 0; i < task.Count; i++)
        {
            if (isRepair == false)
            {
                if (isSell == false)
                {
                    if (task[i].type == name + "Train")
                    {
                        if (!task[i].isDone())
                        {
                            task[i].TakeInfo(count);
                        }
                    }
                }
                else
                {
                    if (task[i].type == "SellTrain")
                    {
                        if (!task[i].isDone())
                        {
                            task[i].TakeInfo(count);
                        }
                    }
                }
            }
            else
            {
                if (task[i].type == "RepairTrain")
                {
                    if (!task[i].isDone())
                    {
                        task[i].TakeInfo(count);
                    }
                }
            }
        }
    }
    public void GetInfo(TownRawScript townRawScript, float count, string name)
    {
        for (int i = 0; i < task.Count; i++)
        {
            if (task[i].type == name)
            {
                if (!task[i].isDone())
                    task[i].TakeInfo(count);
            }
        }
    }
    public void GetInfo(PlayerData pData, float count, string name, bool isEarn)
    {
        for (int i = 0; i < task.Count; i++)
        {
            if (isEarn == true)
            {
                if (task[i].type == name + "Earn")
                {
                    if (!task[i].isDone())
                        task[i].TakeInfo(count);
                }
            }
            else
            {
                if (task[i].type == name + "Spend")
                {
                    if (!task[i].isDone())
                    {
                        if (count >= 0)
                            task[i].TakeInfo(count);
                        else
                            task[i].TakeInfo(count*-1);
                    }
                }
            }
        }
    }
}
