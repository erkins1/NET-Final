'use strict'
//This Javascript code adds in indiviudal agenda items as needed

/*
 * Might need to add a bunch of things to the Meetings controller create 
 * 
 * Each FK might need one of these
 * ViewData["WardID"] = new SelectList(_context.Ward, "WardID", "WardID");
 *      This might actually simplify the initial dropdown list, but definetly the member and hymns
 * 
 * 
 */

//The drop downs don't work with the viewbag. Is that becasue viewbag disapears once the page is loaded?
_SESSION["content"] = content;
console.log(content);

//This creates the dropdown that helps the user choose the item they want to add
function addNewAgendaItem() {
    let dropdownHTML = document.getElementById("Agenda-Items-List");

    //Build the dropdown list
    let dropdown = '<select class="form-control">';
    dropdown += '<option value="Speaker">Speaker</option>';
    dropdown += '<option value="Hymn">Hymn</option>';
    dropdown += '<option value="Special_Event">Special Event</option>';
    dropdown += '<option value="Special_Musical_Number">Special Musical Number</option>';
    dropdown += '</select>';

    //Default setup for speaker 
    let speaker = buildSpeaker();

    //Push everything to the webpage
    dropdownHTML.innerHTML += dropdown + speaker;

}


//An event listener that controls what the user will be able to input
//  runs once the user selects from the dropdown list
//  e.g. Add a hymn or speaker etc.
function changeAgendaItem() {

}


//Build functions for each type of Agenda item
function buildSpeaker() {

    let output = '<div class="form-group">';
    output += '<label asp-for="MemberID" class="control-label">Speaker</label>';
    output += '<select asp-for="MemberID" class="form-control" asp-items="ViewBag.MemberID"></select>';
    output += '</div>';

    return output;
    /*
     * <div class="form-group">
                <label asp-for="First_Name" class="control-label"></label>
                <input asp-for="First_Name" class="form-control" />
                <span asp-validation-for="First_Name" class="text-danger"></span>
            </div>
        <div class="form-group">
                <label asp-for="Presiding" class="control-label"></label>
                <select asp-for="Presiding" class="form-control" asp-items="ViewBag.Presiding"></select>
            </div>
    */

}





//This might be some processing to help write the agenda items to the database





