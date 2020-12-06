
var colNum = 1;

function createPetCard(name, userID, animal, breed, gwKids, gwPets, location, age) {

    if (colNum > 3) {
        colNum = 1;
    }

    var card = document.createElement("div");
    card.setAttribute("style", "display: inline-block; border-style: solid; margin-top: 2em;");
    card.setAttribute("id", "card");

    var image = document.createElement("img");
    image.setAttribute("src", "images/bacon.jpg");
    image.setAttribute("style", "width: 16em; height: 20em;");

    var body = document.createElement("div");
    body.setAttribute("style", "background-color: lightgrey; width: 16em;");

    var name_display = document.createElement("h5");
    name_display.setAttribute("style", "text-align: center; background-color: grey; padding-top: 10px; padding-bottom: 10px;");
    name_display.innerHTML = name;

    var animal_display = document.createElement("p");
    animal_display.innerHTML = "Species: " + animal;

    var breed_display = document.createElement("p");
    breed_display.innerHTML = "Breed: " + breed;

    var gwKids_display = document.createElement("p");
    gwKids_display.innerHTML = "Good With Kids: " + gwKids;

    var gwPets_display = document.createElement("p");
    gwPets_display.innerHTML = "Good With Pets: " + gwPets;

    var location_display = document.createElement("p");
    location_display.innerHTML = "Location: " + location;

    var ageRange_display = document.createElement("p");
    ageRange_display.setAttribute("style", "margin-bottom: 0;");
    ageRange_display.innerHTML = "Age-Range: " + age;

    var likeSec = document.createElement("div");
    likeSec.setAttribute("style", "border-style: solid; width: 16em; height: 3em; background-color: white;");

    var level = document.createElement("a");
    level.setAttribute("class", "level-item");
    level.setAttribute("aria-label", "like");

    var icon = document.createElement("span");
    icon.setAttribute("class", "icon-is-small");

    var fas = document.createElement("i");
    fas.setAttribute("class", "fas fa-heart");
    fas.setAttribute("aria-hidden", "true");

    /*var heart = document.createElement("svg");
    heart.setAttribute("width", "1em");
    heart.setAttribute("height", "1em");
    heart.setAttribute("viewBox", "0 0 16 16");
    heart.setAttribute("class", "bi bi-heart-fill");
    heart.setAttribute("fill", "white");
    heart.setAttribute("xmlns", "http://www.w3.org/2000/svg"); 

    var path = document.createElement("path");
    path.setAttribute("fill-rule", "evenodd");
    path.setAttribute("d", "M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z");*/


    card.appendChild(image);

    body.appendChild(name_display);
    body.appendChild(animal_display);
    body.appendChild(breed_display);
    body.appendChild(gwKids_display);
    body.appendChild(gwPets_display);
    body.appendChild(location_display);
    body.appendChild(ageRange_display);

    icon.appendChild(fas);
    level.appendChild(icon);
    likeSec.appendChild(level);
    //heart.appendChild(path);
    //likeSec.appendChild(heart);

    body.appendChild(likeSec);
    card.appendChild(body);

    var col = document.getElementById("col" + colNum);
    col.appendChild(card);

    colNum++;
}