'use strict'

//This is the event listener
document.getElementById("sectionDropdown").onchange = function () { changeForm() };

function changeForm() {

    //Grab all elements
    let sectionDropDown = document.getElementById("sectionDropdown");
    let member = document.getElementById("MemberID-div");
    let hymn = document.getElementById("HymnID-div");
    let special_event = document.getElementById("Special_Event-div");
    let notes = document.getElementById("Notes-div");
    let subject = document.getElementById("Subject-div");

    //Currently this is hidden and does not get changed
    //Somehow this needs to get set when the user enters the webpage
    let meetingID = document.getElementById("MeetingID-div");

    
    var selectedValue = sectionDropDown.options[sectionDropDown.selectedIndex].value;  //selected value is a string, not an int

    //The switch statement changes the classes on each applicable object so that they only
    // show the applicable parts of the webpage
    //Note: if the user types something into special_event and then changes to something else
    // that text might still exist and get saved to the database
    switch (selectedValue) {   
        case "0": //Speaker
            member.className = "form-group";
            hymn.className = "form-group hide";
            special_event.className = "form-group hide";
            subject.className = "form-group";
            //console.log("Speaker Hit");
            break;
        case "1": //Special Event
            member.className = "form-group hide";
            hymn.className = "form-group hide";
            special_event.className = "form-group";
            subject.className = "form-group hide";
            //console.log("Event Hit");
            break;
        case "2": //Hymn
            member.className = "form-group hide";
            hymn.className = "form-group";
            special_event.className = "form-group hide";
            subject.className = "form-group hide";
            //console.log("Hymn Hit");
            break;
        case "3": //Special Musical Number
            member.className = "form-group hide";
            hymn.className = "form-group hide";
            special_event.className = "form-group";
            subject.className = "form-group hide";
            //console.log("Musical Hit");
            break;
        default:
            member.className = "form-group";
            hymn.className = "form-group hide";
            special_event.className = "form-group hide";
            subject.className = "form-group";
            //console.log("Default Hit");
            break;

    }

}


