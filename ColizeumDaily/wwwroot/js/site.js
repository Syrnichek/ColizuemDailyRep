async function getUser() {
    var userNumber = await document.getElementById("userNumber");
    let url = "/api/userGet?";
    let request = await fetch(url + new URLSearchParams({UserNumber: userNumber.value}));
    let obj = JSON.parse(await request.text());
    
    
    try
    {
        if (request.ok === true) 
        {
            let userNumberBlock = document.getElementById("userNumberBlock");
            let telegramUserNameBlock = document.getElementById("telegramUserNameBlock");
            let daysStreakBlock = document.getElementById("daysStreakBlock");
            let nightPacksStreakBlock = document.getElementById("nightPacksStreakBlock");
            let visitDateBlock = document.getElementById("visitDateBlock");
            let nightPackVisitDateBlock = document.getElementById("nightPackVisitDateBlock");

            userNumberBlock.innerHTML = ("Номер пользователя: " + await obj.usernumber);
            telegramUserNameBlock.innerHTML = ("Телеграм аккаунт пользователя: " + await obj.telegramusername);
            daysStreakBlock.innerHTML = ("Количество дней подряд: " + await obj.daysstreak);
            nightPacksStreakBlock.innerHTML = ("Количество ночных пакетов подряд: " + await obj.nightpacksstreak);
            visitDateBlock.innerHTML = ("Дата последнего посещения: " + await obj.visitdate.slice(0,10));
            nightPackVisitDateBlock.innerHTML = ("Дата последнего ночного пакета: " + await obj.nightpackvisitdate.slice(0,10));
        } 
        else 
        {
            console.log("sosat " + request.status);
        }
    }
    catch (ex)
    {
        console.log(ex);
    }
}

var getUserButton = document.search.getUserButton;
getUserButton.addEventListener("click", getUser)

async function userDailyCheck()
{
    let url = "/api/userVisitCheck?";
    var userNumber = await document.getElementById("userNumber");
    let request = await fetch(url + new URLSearchParams({UserNumber: userNumber.value}));
    
    try
    {
        if (request.status === 200)
        {
            console.log("Пользователь отмечен");
            alert("Пользователь отмечен");
        }
        else if(request.status === 246)
        {
            console.log("Пользователь сегодня уже отмечался");
            alert("Пользователь сегодня уже отмечался"); 
        }
        else
        {
            console.log(request.status);
        }
    }
    catch (ex)
    {
        console.log(ex);
    }
}

var userDailyCheckButton = document.check.userDailyCheckButton;
userDailyCheckButton.addEventListener("click", userDailyCheck);

async function userNightPackCheck() 
{
    let url = "/api/nightPacksCheck?";
    var userNumber = await document.getElementById("userNumber");
    let request = await fetch(url + new URLSearchParams({UserNumber: userNumber.value}));

    try
    {
        if (request.status === 200)
        {
            console.log("Пользователь отмечен");
            alert("Пользователь отмечен");
        }
        else if(request.status === 245)
        {
            console.log("Пользователь сегодня уже отмечался");
            alert("Пользователь сегодня уже отмечался");
        }
        else
        {
            console.log(request.status);
        }
    }
    catch (ex)
    {
        console.log(ex);
    }
}

var userNightPackCheckButton = document.check.userNightPackCheckButton;
userNightPackCheckButton.addEventListener("click", userNightPackCheck);

