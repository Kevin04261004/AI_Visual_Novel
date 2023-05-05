using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _TSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset tsvData = Resources.Load<TextAsset>(_TSVFileName);
        if (tsvData == null)
        {
            Debug.Log("tsv파일의 이름이 잘못되어있습니다.");
            return null;
        }
        string[] data = tsvData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Dialogue dialogue = new Dialogue();
            List<string> contextList = new List<string>();
            List<string> EventList = new List<string>();
            List<string> SkipList = new List<string>();
            dialogue.name = row[1];
            if(!(row[2] == ""))
            {
                dialogue.picture = row[2];
            }
            do
            {
                
                contextList.Add(row[3]);
                EventList.Add(row[4]);
                SkipList.Add(row[5]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");
            dialogue.contexts = contextList.ToArray();
            dialogue.number = EventList.ToArray();
            dialogue.skipnum = SkipList.ToArray();

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();
    }
    public Event[] ParseEvent(string _TSVFileName)
    {
        List<Event> eventList = new List<Event>();
        TextAsset tsvData = Resources.Load<TextAsset>(_TSVFileName);
        if (tsvData == null)
        {
            Debug.Log("tsv파일의 이름이 잘못되어있습니다.");
            return null;
        }
        string[] data = tsvData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Event events = new Event();
            List<string> contextList = new List<string>();
            List<int> changeLineList = new List<int>();
            do
            {

                contextList.Add(row[1]);
                changeLineList.Add(int.Parse(row[2]));
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == "");
            events.context = contextList.ToArray();
            events.changeLine = changeLineList.ToArray();

            eventList.Add(events);
        }
        return eventList.ToArray();
    }
}