//This Javascript code adds in indiviudal agenda items as needed


//This creates the dropdown that helps the user choose the item they want to add
function addNewAgendaItem() {
    let dropdownHTML = document.getElementById("Agenda-Items-List");

    let dropdown = '<Select class="form-control">';
    dropdown += '<option value="Speaker">Speaker</option>';
    dropdown += '<option value="Hymn">Hymn</option>';
    dropdown += '<option value="Special_Event">Special Event</option>';
    dropdown += '<option value="Special_Musical_Number">Special Musical Number</option>';
    dropdown += '</Select>';

    //boxes for speaker 


    dropdownHTML.innerHTML += dropdown;

}


//An event listener that controls what the user will be able to input
//  runs once the user selects from the dropdown list
//  e.g. Add a hymn or speaker etc.
function changeAgendaItem() {

}


//This might be some processing to help write the agenda items to the database





