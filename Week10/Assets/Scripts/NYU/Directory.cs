using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directory : MonoBehaviour
{
    public Text text; //variable for component that displays the text

    //NOTE: notice that this is a list of NYUPerson, but can still hold all subclasses. THAT'S POLYMORPHISM, BABY!
    public List<NYUPerson> nyuPeopleList; //list of people at nyu

    int recordNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        nyuPeopleList = new List<NYUPerson>();

        //make a new NYUFaculty 
        NYUPerson mattParker = new NYUFaculty("Matt Parker", "mp612",1000f,"Code Lab");

        NYUPerson jayde = new NYUStudent("Jayde Zhou", "jz5688", 2.0f, 24);
        NYUPerson milton = new NYUStaff("Milton Chen", "mz0417", 1f);
        NYUPerson eric = new NYUFaculty("Eric Z", "ez2222", 8888f, "Papa Eric!");
        NYUStuGC jasie = new NYUStuGC("Jasie Z", "jz6666", 5.0f, 66, "Sweet Cat!");
        NYUStuITP nunu = new NYUStuITP("Nunu Z", "nz9999", 5.0f, 99, "Best Friend!");
        //we can create NYUStudent from NYUPerson because it is concluded
        
        nyuPeopleList.Add(mattParker); //add mattParker to the 
        nyuPeopleList.Add(jayde);
        nyuPeopleList.Add(eric);
        nyuPeopleList.Add(milton);
        nyuPeopleList.Add(jasie);
        nyuPeopleList.Add(nunu);
        
        UpdateRecord(); //update the text display to show the the info from the first person in the list
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ //if space is pressed
            UpdateRecord(); //change the record to display the next person in the list
        }
    }

    void UpdateRecord(){
        NYUPerson person = nyuPeopleList[recordNum % nyuPeopleList.Count]; //grab the object a person in the list (use % to wrap around)

        text.text = person.ShowRecord(); //display the info for this object

        recordNum++; //increase the recordNum so we show the next person next time through
    }
}
