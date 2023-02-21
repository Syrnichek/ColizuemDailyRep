async function getUser(userNumber) {
    let url = "/api/userGet?UserNumber=78005553535";
    let request = await fetch(url);
    if (request.ok === true)
    {
        await alert("ebi" + request.text());
    }
    else
    {
        alert("sosat " + request.status);  
    }
}

var getUserButton = document.search.getUserButton;
getUserButton.addEventListener("click", getUser);

function userDailyCheck() {
    let url = "/api/userVisitCheck?UserNumber=79660747173";
    
    let request = fetch(url);
    if (request.status === 245)
    {
        alert("ebi");
    }
    else
    {
        alert("sosat " + request.statusText);
    }
}

var userDailyCheckButton = document.check.userDailyCheckButton;
userDailyCheckButton.addEventListener("click", userDailyCheck);

function userNightPackCheck(e) {
    let userNumber = document.search.userNumber;
    let val = userNumber.value;
    if(val.length>5){
        alert("Недопустимая длина строки");
        e.preventDefault();
    }
    else
        alert("Отправка разрешена");
}

var userNightPackCheckButton = document.check.userNightPackCheckButton;
userNightPackCheckButton.addEventListener("click", userNightPackCheck);

function _displayItems(data) {
    alert("sosi" + data);
}