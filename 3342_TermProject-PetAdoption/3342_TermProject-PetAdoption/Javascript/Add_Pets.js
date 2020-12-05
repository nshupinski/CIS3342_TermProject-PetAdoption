
function createPetCard(petList) {

    var colNum = 1;

    for (var i = 0; i < petList.length; i++) {

        if (colNum > 3) {
            colNum = 1;
        }

        var card = document.createElement("div");
        card.setAttribute("style", "width: 6rem; height: 12em; border-style: solid;");

        var image = document.createElement("img");
        image.setAttribute("src", "images/bacon.jpg");
        image.setAttribute("style", "width: 16em; height: 21em;");

        var body = document.createElement("div");
        body.setAttribute("style", "background-color: lightgrey; width: 16em;");

        var name = document.createElement("h5");
        name.innerHTML = petList[i].name;

        var animal = document.createElement("p");
        animal.innerHTML = petList[i].animal;

        var breed = document.createElement("p");
        breed.innerHTML = petList[i].breed;

        var gwKids = document.createElement("p");
        gwKids.innerHTML = petList[i].gwKids;

        var gwPets = document.createElement("p");
        gwPets.innerHTML = petList[i].gwPets;

        var location = document.createElement("p");
        location.innerHTML = petList[i].location;

        var ageRange = document.createElement("p");
        ageRange.innerHTML = petList[i].ageRange;

        card.appendChild(image);
        body.appendChild(name);
        body.appendChild(animal);
        body.appendChild(breed);
        body.appendChild(gwKids);
        body.appendChild(gwPets);
        body.appendChild(location);
        body.appendChild(ageRange);
        card.appendChild(body);
        var col2 = document.getElementById("col" + colNum);
        col2.appendChild(card);

        colNum++;
    }
}