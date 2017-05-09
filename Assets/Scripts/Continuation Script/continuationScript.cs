using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

namespace Midgaard
{
    public class continuationScript : MonoBehaviour
    {
        StreamWriter writer;
        string desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        public Text buttonText;
        public Text continueTxt;
        public Text beginTxt;
        public Button[] selections;
      
        public Button btn, next;
        public Slider slider;
        public Canvas canvas;
        public float sliderValue;
        

        private int count = 0;
        int i = 0;
        private string[] cards = new string[33];
        private string[] strings = {"Karakter Progression", "Karakter Styrke", "Anskaffelse af Items", "Status i spillet", "At mestre spillets mechanics", "Optimering af mit playthrough", "Planlægning af karakter", "Analyserer spillets mechanics", "Konkurrence med andre spillere", "Provokation af andre spillere", "Dominere andre spillere", "Casual chatting", "At hjælp andre", "At skabe venskaber", "At tale om personlige problemer", "Selv åbenbarelse", "At støtte hinanden", "Samarbejde", "At være del af en gruppe", "Gruppe præstationer", "At udforske spilverden", "At udforske historien", "At finde skjulte ting", "At blive opslugt i verden", "At find på min karkaters baggrundshistorie", "At værer en anden personlighed", "At finde på historier om min karakter", "At costumize min karakter", "At min karakter ser sej/godt ud", "At min karakter er unique", "At undslippe virkeligheden", "at undgå virkelighedens problemer", "At slappe af" };
        private List<string> selected = new List<string>();
        private List<string> added = new List<string>();
        private bool deciding = true;
        private bool eventStarted = false;
        private bool missingCards = false;
        private float percentage = 0f;

        bool add = false;
        bool remove = false;
        bool runCoroutine = true;
        // Use this for initialization
        void Start()

        {
            DontDestroyOnLoad(this);
            
            Debug.Log("" + strings.Length);     
            foreach (Button btns in selections)
            {
                btns.onClick.AddListener(Select);
            }
            
           
            btn.onClick.AddListener(writeToTextFile);
            next.onClick.AddListener(goToSorting);
            ContinueEvent();
            count++;
        }

        private void OpenStream() {
            string name = "CardSelection_Results.txt";
            name = Path.Combine(desktop, name);
            writer = new StreamWriter(name, true);
        }
        
        private void OnLevelWasLoaded()
        {
            if(writer.BaseStream != null)
            {
                writer.Flush();
                writer.Close();
            }
        }

        public void onValueChanged(float newValue)
        {
            var temp = GameObject.Find("SliderHolder").gameObject.transform.FindChild("Percentage").GetComponent<Text>();
            newValue = newValue * 100;            
            temp.text = newValue.ToString() + "%";            

        }
        
        public void goToSorting()
        {
            Debug.Log("goToSorting");
                OpenStream();
            Debug.Log("OpenStream");
                writer.WriteLine("Agreement with statement: " + (slider.value * 100) + "%");
                slider.onValueChanged.RemoveListener(onValueChanged);
                slider.value = .5f;

                var temp = GameObject.Find("Canvas").gameObject;
                temp.transform.FindChild("ButtonHolder").transform.gameObject.SetActive(true);
                GameObject.Find("SliderHolder").gameObject.SetActive(false);

            
            
            
        }
        
        public void Select()
        {

           
            
            var obj = EventSystem.current.currentSelectedGameObject;
            var txt = obj.GetComponentInChildren<Text>().text;
            var bt = obj.GetComponent<Button>();
            var foundDuplicate = false;
                for(int i = 0; i < selected.Count; i++)
                {
                    if(txt == selected[i])
                    {
                    foundDuplicate = true;
                        selected.RemoveAt(i);
                        i--;
                    remove = true;
                    StartCoroutine(DisplaySelect());
                }             
                }
            if (!foundDuplicate)
            {
                add = true;
                selected.Add(txt);
            }

            Debug.Log(txt);
        }
        void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 36;

            if (missingCards)
            {
                GUI.Label(new Rect(Screen.width / 10, Screen.height / 3, 100, 100), "Du har kun valgt " + selected.Count + ". Vælg " + (5 - selected.Count) + " mere.", style);
                if (runCoroutine)
                    StartCoroutine(DisplaySelect());
            }

            if (add)
            {
                
                GUI.Label(new Rect(Screen.width / 10, Screen.height / 3 , 100, 100), "Tilføjet", style);
                if (runCoroutine)
                    StartCoroutine(DisplaySelect());
            }

            if (remove)
            {
                
                GUI.Label(new Rect(Screen.width / 10, Screen.height / 3 , 100, 100), "Fjernet", style);

                if (runCoroutine)
                    StartCoroutine(DisplaySelect());

            }
            
           
            
         
        }

        IEnumerator DisplaySelect()
        {
            runCoroutine = false;
            Debug.Log("Display");
            yield return new WaitForSecondsRealtime(2);

            Debug.Log("hallo " + add + remove + missingCards);
            add = false;
            remove = false;
            missingCards = false;
            runCoroutine = true;
            yield return null;
            
            
        }
        public void ContinueEvent()

        {
           
            slider.onValueChanged.AddListener(onValueChanged);      
            setButtonText();
            eventStarted = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (deciding)
            { 
                canvas.transform.gameObject.SetActive(true);
                Time.timeScale = 0;
                if (count > 0)
                {
                    continueTxt.gameObject.SetActive(true);
                    beginTxt.gameObject.SetActive(false);
                }

            }

        }

        int GetRandom(List<int> added) {
            int newRand = Random.Range(0, strings.Length);
            if (!added.Contains(newRand))
                return newRand;
            else
                return GetRandom(added);
        }

        public void setButtonText()
        {
            var rnd = Random.Range(0, strings.Length-1);
            List<int> addedInts = new List<int>();
            int i = 0;
            while (i < strings.Length) {
                int random = GetRandom(addedInts);
                addedInts.Add(random);
                selections[i].transform.FindChild("Text").transform.gameObject.GetComponent<Text>().text = strings[random];
                i++;

            }
           
         
        }



        public void writeToTextFile()
        {

            if (selected.Count != 5)
            {
                missingCards = true;
               
            }
            else if (selected.Count == 5)
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    writer.WriteLine(selected[i]);
                }

                writer.Flush();
                writer.Close();
                Time.timeScale = 1;
                eventStarted = false;
                Cursor.lockState = CursorLockMode.Locked;
                canvas.transform.gameObject.SetActive(false);
                transform.Find("ButtonHolder").gameObject.SetActive(false);
                transform.Find("SliderHolder").gameObject.SetActive(true);

            }
           
        }
    }
}
